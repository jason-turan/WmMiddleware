<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns="http://www.demandware.com/xml/impex/inventory/2007-05-31"       xmlns:xsl="http://www.w3.org/1999/XSL/Transform"       xmlns:x="http://10.1.0.87/SimpleSource.xsd"      xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl x"  >
  <xsl:output method="xml" indent="yes"/>
  <xsl:strip-space elements="*"/>
  <xsl:template match="/">
    <xsl:apply-templates />
  </xsl:template>

  <xsl:template match="NewDataSet">
    <inventory>
      <inventory-list>
        <header list-id="inventory_NewBalance_UK">
          <default-instock>false</default-instock>
        </header>
        <records>
          <xsl:apply-templates select="Table" />
        </records>
      </inventory-list>
    </inventory>
  </xsl:template>

  <xsl:template match="Table">
    <xsl:element name="record">
      <xsl:apply-templates select="SKU"/>
      <xsl:apply-templates select="Quantity"/>
    </xsl:element>
  </xsl:template>

  <xsl:template match="SKU">
    <xsl:attribute name="product-id">
      <xsl:value-of select="."/>
    </xsl:attribute>
  </xsl:template>

  <xsl:template match="Quantity">
    <xsl:element name="allocation">
      <xsl:value-of select="."/>
    </xsl:element>
  </xsl:template>

</xsl:stylesheet>
