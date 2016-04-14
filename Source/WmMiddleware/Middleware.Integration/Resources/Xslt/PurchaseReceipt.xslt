<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt"   exclude-result-prefixes="msxsl"
 >
  <xsl:output method="xml" indent="yes" standalone="yes"/>

  <xsl:key name="k_id" match="Table" use="POReceiptDetailID/text()" />

  <xsl:variable name="receipts" select="NewDataSet/Table[generate-id() = generate-id(key('k_id', POReceiptDetailID/text())[1])]" />
  <xsl:variable name="lines" select="NewDataSet/Table"/>

  <!--<xsl:variable name="company_key_id" select="'3'"/>-->
  
  <xsl:template match="/">
    <Objects>
      <xsl:call-template name="poReceipts"/>
    </Objects>
  </xsl:template>

  <xsl:template name="poReceipts">
    <xsl:for-each select="$receipts">
      <xsl:variable name="po_id" select="POReceiptDetailID/text()" />
      <PurchaseReceipt xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">

        <record_id>
          <xsl:value-of select="record_id"/>
        </record_id>

        <BatchKey xmlns="http://schemas.microsoft.com/dynamics/gp/2006/01">
          <CompanyKey>
            <Id xmlns="http://schemas.microsoft.com/dynamics/2006/01">
              <xsl:value-of select="company_key_id"/>
            </Id>
          </CompanyKey>
          <Source>
            <xsl:value-of select="batch_source"/>
          </Source>
          <Id>
            <xsl:value-of select="batch_id"/>
          </Id>
          <CreatedDateTime>
            <xsl:value-of select="batch_create_dt"/>
          </CreatedDateTime>
        </BatchKey>

        
        <Key  xmlns="http://schemas.microsoft.com/dynamics/gp/2006/01">
          <CompanyKey xmlns="http://schemas.microsoft.com/dynamics/gp/2006/01">
            <Id   xmlns="http://schemas.microsoft.com/dynamics/gp/2006/01">
              <xsl:value-of select="company_key_id"/>
            </Id>
          </CompanyKey>
          <Id>
            <xsl:value-of select="InvoiceNumber"/>
          </Id>
        </Key>

        <VendorDocumentNumber xmlns="http://schemas.microsoft.com/dynamics/gp/2006/01">
          <xsl:value-of select="vendor_document_number"/>
        </VendorDocumentNumber>


        <Date xmlns="http://schemas.microsoft.com/dynamics/gp/2006/01">
          <xsl:value-of select="shippeddatetimereference"/>
        </Date>
        <PostedDate xmlns="http://schemas.microsoft.com/dynamics/gp/2006/01">
          <xsl:value-of select="shippeddatetimereference"/>
        </PostedDate>
        
        <!-- don't need because we have the PO number. Keep it here for now -->
        
        <VendorKey xmlns="http://schemas.microsoft.com/dynamics/gp/2006/01">
          <CompanyKey>
            <Id xmlns="http://schemas.microsoft.com/dynamics/2006/01">
              <xsl:value-of select="company_key_id"/>
            </Id>
          </CompanyKey>
          <Id>
            <xsl:value-of select="normalize-space(vendor_key_id)"/>
          </Id>
        </VendorKey>

                
        <Lines xmlns="http://schemas.microsoft.com/dynamics/gp/2006/01" >

          <xsl:for-each select="$lines">
            <xsl:if test="POReceiptDetailID=$po_id">
              <PurchaseReceiptLine xmlns="http://schemas.microsoft.com/dynamics/gp/2006/01">

                <PurchaseOrderKey>
                  <CompanyKey>
                    <Id xmlns="http://schemas.microsoft.com/dynamics/2006/01">
                      <xsl:value-of select="company_key_id"/>
                    </Id>
                  </CompanyKey>
                  <Id>
                    <xsl:value-of select="normalize-space(PONumber)"/>
                  </Id>
                </PurchaseOrderKey>
                
                <ItemKey>
                  <CompanyKey>
                    <Id xmlns="http://schemas.microsoft.com/dynamics/2006/01">
                      <xsl:value-of select="company_key_id"/>
                    </Id>
                  </CompanyKey>
                  <Id>
                    <xsl:value-of select="normalize-space(item_key_id)"/>
                  </Id>
                </ItemKey>

                <!--
                <VendorItemNumber>
                  <xsl:value-of select="vendor_item_number"/>
                </VendorItemNumber>
                -->

                <!--
                <UofM>
                  <xsl:value-of select="UOM"/>
                </UofM>
                -->

                <!--
                <UnitCost>
                  <Currency>USD</Currency>
                  <Value>
                    <xsl:value-of select="UnitPrice"/>
                  </Value>
                  <DecimalDigits>2</DecimalDigits>
                </UnitCost>
                -->
                
                <!-- we may need this -->
                <!--
                <ExtendedCost>
                  <Currency>USD</Currency>
                  <Value>
                    <xsl:value-of select="UnitPrice"/>
                  </Value>
                  <DecimalDigits>2</DecimalDigits>
                </ExtendedCost>
                -->
                
                <IsNonInventory>false</IsNonInventory>

                <QuantityShipped>
                  <Value>
                    <xsl:value-of select="qty"/>
                  </Value>
                  <DecimalDigits>0</DecimalDigits>
                </QuantityShipped>

                <!--
                <WarehouseKey>
                  <CompanyKey>
                    <Id xmlns="http://schemas.microsoft.com/dynamics/2006/01">
                      <xsl:value-of select="company_key_id"/>
                    </Id>
                  </CompanyKey>
                  <Id>01</Id>
                </WarehouseKey>
                -->

                <!--
                <PurchaseOrderLineKey>
                  <CompanyKey>
                    <Id xmlns="http://schemas.microsoft.com/dynamics/2006/01">
                      <xsl:value-of select="company_key_id"/>
                    </Id>
                  </CompanyKey>
                  <LineSequenceNumber>
                    <xsl:value-of select="LineNumber"/>
                  </LineSequenceNumber>
                </PurchaseOrderLineKey>
                -->
                
              </PurchaseReceiptLine>

            </xsl:if>
          </xsl:for-each>

        </Lines>
      </PurchaseReceipt>
    </xsl:for-each>
  </xsl:template>
</xsl:stylesheet>
