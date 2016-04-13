<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns="http://www.demandware.com/xml/impex/geolocation/2007-05-01"
				xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
				xmlns:x="http://10.1.0.87/SimpleSource.xsd"
				xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl x"
>
  <xsl:output method="xml" indent="yes"/>

  <xsl:strip-space elements="*"/>

  <xsl:template match="/">
    <xsl:apply-templates />
  </xsl:template>

  <xsl:template match="NewDataSet">
    <geolocations country-code="GB">
      <xsl:apply-templates select="Table" />
    </geolocations>
  </xsl:template>

  <xsl:template match="Table">
    <geolocation>
      <xsl:attribute name="postal-code">
        <xsl:apply-templates select="ZIP"/>
      </xsl:attribute>
      <city xml:lang="x-default">
        <xsl:apply-templates select="City"/>
      </city>
      <state xml:lang="x-default"/>
      <longitude>
        <xsl:apply-templates select="Lng"/>
      </longitude>
      <latitude>
        <xsl:apply-templates select="Lat"/>
      </latitude>
    </geolocation>
  </xsl:template>

  <xsl:template match="ZIP">
    <xsl:value-of select="."/>
  </xsl:template>

  <xsl:template match="City">
    <xsl:value-of select="."/>
  </xsl:template>

  <xsl:template match="Lng">
    <xsl:value-of select="."/>
  </xsl:template>

  <xsl:template match="Lat">
    <xsl:value-of select="."/>
  </xsl:template>

</xsl:stylesheet>
