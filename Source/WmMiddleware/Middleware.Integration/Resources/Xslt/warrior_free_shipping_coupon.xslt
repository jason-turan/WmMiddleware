<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0"
                xmlns="http://www.demandware.com/xml/impex/coupon/2008-06-17"
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                xmlns:x="http://integrationmanager/CouponDefinition.xsd"
                xmlns:date="http://exslt.org/dates-and-times"
                xmlns:msxsl="urn:schemas-microsoft-com:xslt"
                extension-element-prefixes="date"
                exclude-result-prefixes="msxsl x"
>
  <xsl:import href="C:\IntegrationManager\xslt\date.add.template.xsl"/>

  <xsl:output method="xml" indent="yes"/>

  <xsl:template match="/">
    <coupons>
      <xsl:call-template name="processLoop">
        <xsl:with-param name="i" select="0"/>
        <xsl:with-param name="beginDate" select="//x:dateToBegin"/>
        <xsl:with-param name="daysToGenerate" select="//x:daysToGenerate"/>
        <xsl:with-param name="daysOfActiveCoupons" select="//x:daysOfActiveCoupons"/>
        <xsl:with-param name="numberOfCodes" select="//x:numberOfCodes"/>
        <xsl:with-param name="couponCodePrefix" select="//x:couponCodePrefix"/>
        <xsl:with-param name="couponIdFormat" select="//x:couponIdFormat"/>
      </xsl:call-template>
    </coupons>
  </xsl:template>

  <xsl:template name="processLoop">
    <xsl:param name="i"/>
    <xsl:param name="beginDate"/>
    <xsl:param name="daysToGenerate" />
    <xsl:param name="daysOfActiveCoupons" />
    <xsl:param name="numberOfCodes" />
    <xsl:param name="couponCodePrefix" />
    <xsl:param name="couponIdFormat" />
    <xsl:if test="$i &lt; $daysToGenerate">
      <xsl:variable name="newBeginDate">
        <xsl:call-template name="date:add">
          <xsl:with-param name="date-time" select="string($beginDate)"/>
          <xsl:with-param name="duration">P<xsl:value-of select="$i"/>D</xsl:with-param>
        </xsl:call-template>
      </xsl:variable>
      <xsl:variable name="duration" select="$daysOfActiveCoupons"/>
      <xsl:variable name="endDate">
        <xsl:call-template name="date:add">
          <xsl:with-param name="date-time" select="string($newBeginDate)"/>
          <xsl:with-param name="duration">P<xsl:value-of select="$daysOfActiveCoupons"/>D</xsl:with-param>
        </xsl:call-template>
      </xsl:variable>
      <coupon>
        <xsl:attribute name="coupon-id">
          <xsl:value-of select="$couponIdFormat"/>_<xsl:value-of select="$newBeginDate"/>_<xsl:value-of select="$endDate"/>
        </xsl:attribute>
        <enabled-flag>true</enabled-flag>
        <redemption-limits>
          <limit-per-code>1</limit-per-code>
          <limit-per-customer>1</limit-per-customer>
        </redemption-limits>
        <system-codes>
          <max-number-of-codes>
            <xsl:value-of select="$numberOfCodes"/>
          </max-number-of-codes>
          <code-prefix>
            <xsl:value-of select="$couponCodePrefix"/>
          </code-prefix>
        </system-codes>
      </coupon>
      <xsl:call-template name="processLoop">
        <xsl:with-param name="i">
          <xsl:value-of select="$i + 1"/>
        </xsl:with-param>
        <xsl:with-param name="beginDate" select="$beginDate"/>
        <xsl:with-param name="daysToGenerate" select="$daysToGenerate"/>
        <xsl:with-param name="daysOfActiveCoupons" select="$daysOfActiveCoupons"/>
        <xsl:with-param name="numberOfCodes" select="$numberOfCodes"/>
        <xsl:with-param name="couponCodePrefix" select="$couponCodePrefix"/>
        <xsl:with-param name="couponIdFormat" select="$couponIdFormat"/>
      </xsl:call-template>
    </xsl:if>  
  </xsl:template>
</xsl:stylesheet>