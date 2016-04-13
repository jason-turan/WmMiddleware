<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt"   exclude-result-prefixes="msxsl"
 >
  <xsl:output method="xml" indent="yes" standalone="yes"/>

  <!--<xsl:variable name="company_key_id" select="'3'"/>-->

  <xsl:template match="/">
    <Objects>
      <xsl:apply-templates select="NewDataSet/Table" />
    </Objects>
  </xsl:template>

  <xsl:template name="inventoryVariance" match="Table">          
      <InventoryVariance xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">

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
          <!-- use the doc_id instead of the record_id for this integration -->
          <Id><xsl:value-of select="doc_id"/></Id>          
        </Key>

        <Date xmlns="http://schemas.microsoft.com/dynamics/gp/2006/01">
          <xsl:value-of select="inventory_variance_date"></xsl:value-of>
        </Date>        
        
        <Lines xmlns="http://schemas.microsoft.com/dynamics/gp/2006/01" >
          
          <InventoryVarianceLine xmlns="http://schemas.microsoft.com/dynamics/gp/2006/01">
            <Key>
              <CompanyKey>
                <Id xmlns="http://schemas.microsoft.com/dynamics/2006/01">
                  <xsl:value-of select="company_key_id"/>
                </Id>
              </CompanyKey>
            </Key>
                
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

            <Quantity>
              <Value>
                <xsl:value-of select="qty"/>
              </Value>
              <DecimalDigits>0</DecimalDigits>
            </Quantity>

            <!--
            <UnitCost>
              <Currency>USD</Currency>
              <Value>
                <xsl:value-of select="UnitPrice"/>
              </Value>
              <DecimalDigits>2</DecimalDigits>
            </UnitCost>
            -->

            <!--
            <UofM>
              <xsl:value-of select="UOM"/>
            </UofM>
            -->
            <xsl:if test="variance_account">
              <InventoryGLAccount>
                <CompanyKey>
                  <Id xmlns="http://schemas.microsoft.com/dynamics/2006/01">
                    <xsl:value-of select="company_key_id"/>
                  </Id>
                </CompanyKey>
                <Id>
                  <xsl:value-of select="variance_account"/>
                </Id>
                <IsEncrypted>false</IsEncrypted>
              </InventoryGLAccount>
            </xsl:if>

            <xsl:if test="gl_account">
              <InventoryOffsetGLAccount>
                <CompanyKey>
                  <Id xmlns="http://schemas.microsoft.com/dynamics/2006/01">
                    <xsl:value-of select="company_key_id"/>
                  </Id>
                </CompanyKey>
                <Id>
                  <xsl:value-of select="gl_account"/>
                </Id>
                <IsEncrypted>false</IsEncrypted>
              </InventoryOffsetGLAccount>
            </xsl:if>            
            
            <WarehouseKey>
              <CompanyKey>
                <Id xmlns="http://schemas.microsoft.com/dynamics/2006/01">
                  <xsl:value-of select="company_key_id"/>
                </Id>
              </CompanyKey>
              <Id>01</Id>
            </WarehouseKey>
                
          </InventoryVarianceLine>
        </Lines>
      </InventoryVariance>    
  </xsl:template>
</xsl:stylesheet>
