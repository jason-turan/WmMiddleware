<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt"   exclude-result-prefixes="msxsl"
 >
    <xsl:output method="xml" indent="yes" standalone="yes"/>

  <xsl:key name="k_id" match="Table" use="POReceiptDetailID/text()" />

  <xsl:variable name="invoices" select="NewDataSet/Table[generate-id() = generate-id(key('k_id', POReceiptDetailID/text())[1])]" />
  <xsl:variable name="lines" select="NewDataSet/Table"/>

  <!--<xsl:variable name="company_key_id" select="'3'"/>-->
  
  <xsl:template match="/">
    <Objects>
      <xsl:call-template name="invoices"/>
    </Objects>
  </xsl:template>

  <xsl:template name="invoices">
    <xsl:for-each select="$invoices">
      <xsl:variable name="po_id" select="POReceiptDetailID/text()" />
      <PurchaseInvoice xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">

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
            <!--<xsl:value-of select="record_id"/>-->
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
        
        <VendorKey xmlns="http://schemas.microsoft.com/dynamics/gp/2006/01">
          <CompanyKey>
            <Id xmlns="http://schemas.microsoft.com/dynamics/2006/01">
              <xsl:value-of select="company_key_id"/>
            </Id>
          </CompanyKey>
          <Id xmlns="http://schemas.microsoft.com/dynamics/gp/2006/01">
            <xsl:value-of select="normalize-space(vendor_key_id)"/>
          </Id>
        </VendorKey>

        
        <Distributions xmlns="http://schemas.microsoft.com/dynamics/gp/2006/01">
         
          <PurchaseDistribution>
            
            <GLAccountKey>
              <CompanyKey>
                <Id xmlns="http://schemas.microsoft.com/dynamics/2006/01">
                  <xsl:value-of select="company_key_id"/>
                </Id>
              </CompanyKey>
              <Id>
                <xsl:value-of select="debit_gl_account"/>
              </Id>
              <IsEncrypted>false</IsEncrypted>
            </GLAccountKey>

            <DebitAmount>
              <Currency>USD</Currency>
              <Value>
                <xsl:value-of select="sum_po_unitcost"/>
              </Value>
              <DecimalDigits>2</DecimalDigits>
            </DebitAmount>                       
            
            <DistributionTypeKey>
              <CompanyKey>
                <Id xmlns="http://schemas.microsoft.com/dynamics/2006/01">
                  <xsl:value-of select="company_key_id"/>
                </Id>
              </CompanyKey>
              <Id>1</Id>
            </DistributionTypeKey>
          </PurchaseDistribution>          
          
          <PurchaseDistribution>
            <GLAccountKey>
              <CompanyKey>
                <Id xmlns="http://schemas.microsoft.com/dynamics/2006/01">
                  <xsl:value-of select="company_key_id"/>
                </Id>
              </CompanyKey>
              <Id>
                <xsl:value-of select="credit_gl_account"/>
              </Id>
              <IsEncrypted>false</IsEncrypted>
            </GLAccountKey>

            <CreditAmount>
              <Currency>USD</Currency>
              <Value>
                <xsl:value-of select="sum_li_unitcost"/>
              </Value>
              <DecimalDigits>2</DecimalDigits>
            </CreditAmount>

            <DistributionTypeKey>
              <CompanyKey>
                <Id xmlns="http://schemas.microsoft.com/dynamics/2006/01">
                  <xsl:value-of select="company_key_id"/>
                </Id>
              </CompanyKey>
              <Id>7</Id>
            </DistributionTypeKey>
          </PurchaseDistribution>


          <xsl:if test="ppv_gl_account_type"> <!--this could be null if there is a 0 for ppv-->
            <PurchaseDistribution>
              <GLAccountKey>
                <CompanyKey>
                  <Id xmlns="http://schemas.microsoft.com/dynamics/2006/01">
                    <xsl:value-of select="company_key_id"/>
                  </Id>
                </CompanyKey>
                <Id>
                  <xsl:value-of select="ppv_gl_account"/>
                </Id>
                <IsEncrypted>false</IsEncrypted>
              </GLAccountKey>
              
              <xsl:choose>
                <xsl:when test="ppv_gl_account_type='credit'">
                  <CreditAmount>
                    <Currency>USD</Currency>
                    <Value>
                      <xsl:value-of select="ppv"/>
                    </Value>
                    <DecimalDigits>2</DecimalDigits>
                  </CreditAmount>
                </xsl:when>

                <xsl:when test="ppv_gl_account_type='debit'">
                  <DebitAmount>
                    <Currency>USD</Currency>
                    <Value>
                      <xsl:value-of select="ppv"/>
                    </Value>
                    <DecimalDigits>2</DecimalDigits>
                  </DebitAmount>
                </xsl:when>

              </xsl:choose>

              <DistributionTypeKey>
                <CompanyKey>
                  <Id xmlns="http://schemas.microsoft.com/dynamics/2006/01">
                    <xsl:value-of select="company_key_id"/>
                  </Id>
                </CompanyKey>
                <Id>1</Id>
              </DistributionTypeKey>
            </PurchaseDistribution>

          </xsl:if>
          
        </Distributions>
        

        <Lines xmlns="http://schemas.microsoft.com/dynamics/gp/2006/01" >

          <xsl:for-each select="$lines">
            <xsl:if test="POReceiptDetailID=$po_id">
              <PurchaseInvoiceLine>

                
                <ItemKey>
                  <CompanyKey>
                    <Id xmlns="http://schemas.microsoft.com/dynamics/2006/01">
                      <xsl:value-of select="company_key_id"/>
                    </Id>
                  </CompanyKey>
                  <Id>
                    <xsl:value-of select="item_key_id"/>
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

                
                <UnitCost>
                  <Currency>USD</Currency>
                  <Value>
                    <xsl:value-of select="UnitPrice"/>
                  </Value>
                  <DecimalDigits>2</DecimalDigits>
                </UnitCost>
                
                
                <!--
                <IsNonInventory>false</IsNonInventory>
                -->
                
                <QuantityInvoiced>
                  <Value>
                    <xsl:value-of select="qty"/>
                  </Value>
                  <DecimalDigits>0</DecimalDigits>
                </QuantityInvoiced>

                <ExtendedCost>
                  <Currency>USD</Currency>
                  <Value>
                    <xsl:value-of select="ExtendedCost"/>
                  </Value>
                  <DecimalDigits>2</DecimalDigits>
                </ExtendedCost>


                <WarehouseKey>
                  <CompanyKey>
                    <Id xmlns="http://schemas.microsoft.com/dynamics/2006/01">
                      <xsl:value-of select="company_key_id"/>
                    </Id>
                  </CompanyKey>
                  <Id>01</Id>
                </WarehouseKey>


                <PurchaseOrderKey>
                  <CompanyKey>
                    <Id xmlns="http://schemas.microsoft.com/dynamics/2006/01">
                      <xsl:value-of select="company_key_id"/>
                    </Id>
                  </CompanyKey>
                  <Id>
                    <xsl:value-of select="PONumber"/>
                  </Id>
                </PurchaseOrderKey>

                <!--
                <PurchaseOrderLineKey>
                  <CompanyKey>
                    <Id xmlns="http://schemas.microsoft.com/dynamics/2006/01">
                      <xsl:value-of select="company_key_id"/>
                    </Id>
                  </CompanyKey>
                  
                  <LineSequenceNumber>
                    
                    <xsl:value-of select="LineNumber"/>
                    <xsl:text>49152</xsl:text>
                  </LineSequenceNumber>
                </PurchaseOrderLineKey>
                -->
                
              </PurchaseInvoiceLine>

            </xsl:if>
          </xsl:for-each>
          
        </Lines>        
      </PurchaseInvoice>
    </xsl:for-each>
  </xsl:template>  
</xsl:stylesheet>
