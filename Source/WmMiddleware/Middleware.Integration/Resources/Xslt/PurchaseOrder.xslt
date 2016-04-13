<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt"   exclude-result-prefixes="msxsl"
 >
  <xsl:output method="xml" indent="yes" standalone="yes"/>

  <xsl:key name="k_id" match="Table" use="header_id/text()" />

  <xsl:variable name="headers" select="NewDataSet/Table[generate-id() = generate-id(key('k_id', header_id/text())[1])]" />
  <xsl:variable name="lines" select="NewDataSet/Table"/>

  <!--<xsl:variable name="company_key_id" select="'3'"/>-->

  <xsl:template match="/">
    <Objects>
      <xsl:call-template name="headers"/>
    </Objects>
  </xsl:template>

  <xsl:template name="headers">
    <xsl:for-each select="$headers">
      <xsl:variable name="header_id" select="header_id/text()" />
      <PurchaseOrder xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
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
            <xsl:value-of select="PONumber"/>
          </Id>
        </Key>

        <Type xmlns="http://schemas.microsoft.com/dynamics/gp/2006/01">
          <xsl:value-of select="po_type"/>
        </Type>

        <VendorKey xmlns="http://schemas.microsoft.com/dynamics/gp/2006/01">
          <CompanyKey>
            <Id xmlns="http://schemas.microsoft.com/dynamics/2006/01">
              <xsl:value-of select="company_key_id"/>
            </Id>
          </CompanyKey>
          <Id>
            <xsl:value-of select="VendorID"/>            
          </Id>
        </VendorKey>

        <xsl:if test="po_type='Drop Ship'">
        <CustomerKey xmlns="http://schemas.microsoft.com/dynamics/gp/2006/01">
          <CompanyKey>
            <Id xmlns="http://schemas.microsoft.com/dynamics/gp/2006/01">
              <xsl:value-of select="company_key_id"/>
            </Id>
          </CompanyKey>
          <Id>
            <xsl:value-of select="customer_key_id"/>
          </Id>
        </CustomerKey>
        </xsl:if>

        <Date xmlns="http://schemas.microsoft.com/dynamics/gp/2006/01">
          <xsl:value-of select="PODate"/>
        </Date>

        <PromisedDate xmlns="http://schemas.microsoft.com/dynamics/gp/2006/01">
          <xsl:value-of select="PromisedDate"/>
        </PromisedDate>

        <RequestedDate xmlns="http://schemas.microsoft.com/dynamics/gp/2006/01">
          <xsl:value-of select="CancelDate"/>
        </RequestedDate>

        <!--
        <Subtotal xmlns="http://schemas.microsoft.com/dynamics/gp/2006/01">
          <Currency>USD</Currency>
          <Value>
            <xsl:value-of select="Subtotal"/>
          </Value>
          <DecimalDigits>2</DecimalDigits>
        </Subtotal>
        -->
        
        <Lines xmlns="http://schemas.microsoft.com/dynamics/gp/2006/01" >
          <xsl:for-each select="$lines">
            <xsl:if test="header_id=$header_id">
              <PurchaseOrderLine xmlns="http://schemas.microsoft.com/dynamics/gp/2006/01">

                <Key>
                  <CompanyKey>
                    <Id xmlns="http://schemas.microsoft.com/dynamics/2006/01">
                      <xsl:value-of select="company_key_id"/>
                    </Id>
                  </CompanyKey>                  
                  
                  <!--
                  <PurchaseTransactionKey>
                    <CompanyKey>
                      <Id xmlns="http://schemas.microsoft.com/dynamics/2006/01">-1</Id>
                    </CompanyKey>
                  </PurchaseTransactionKey>
                  <LineSequenceNumber>1</LineSequenceNumber>
                  -->
                </Key>

                
                <WarehouseKey>
                  <CompanyKey>
                    <Id xmlns="http://schemas.microsoft.com/dynamics/2006/01">
                      <xsl:value-of select="company_key_id"/>
                    </Id>
                  </CompanyKey>
                  <Id>01</Id>
                </WarehouseKey>
                
                
                <ItemKey>
                  <CompanyKey>
                    <Id xmlns="http://schemas.microsoft.com/dynamics/2006/01">
                      <xsl:value-of select="company_key_id"/>
                    </Id>
                  </CompanyKey>
                  <Id>
                    <xsl:value-of select="SKU"/>
                  </Id>
                </ItemKey>

                <QuantityOrdered>
                  <Value>
                    <xsl:value-of select="QtyOrder"/>
                  </Value>
                  <DecimalDigits>0</DecimalDigits>
                </QuantityOrdered>

                <IsNonInventory>false</IsNonInventory>
                
                <UofM>
                  <xsl:value-of select="UOM"/>
                </UofM>

                <UnitCost>
                  <Currency>USD</Currency>
                  <Value>
                    <xsl:value-of select="Cost"/>
                  </Value>
                  <DecimalDigits>4</DecimalDigits>
                </UnitCost>

                <WarehouseKey>
                  <CompanyKey>
                    <Id xmlns="http://schemas.microsoft.com/dynamics/2006/01">
                      <xsl:value-of select="company_key_id"/>
                    </Id>
                  </CompanyKey>
                  <Id>01</Id>
                </WarehouseKey>
                
              </PurchaseOrderLine>

            </xsl:if>
          </xsl:for-each>

        </Lines>
      </PurchaseOrder>
    </xsl:for-each>
  </xsl:template>
</xsl:stylesheet>
