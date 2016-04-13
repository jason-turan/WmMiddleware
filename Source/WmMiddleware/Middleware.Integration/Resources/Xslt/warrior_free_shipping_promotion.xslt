<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0"
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                xmlns:x="http://integrationmanager/CouponDefinition.xsd"
                xmlns:msxsl="urn:schemas-microsoft-com:xslt"
                xmlns:date="http://exslt.org/dates-and-times"
                xmlns="http://www.demandware.com/xml/impex/promotion/2008-01-31"
                extension-element-prefixes="date"
                exclude-result-prefixes="msxsl x"
>
  <xsl:import href="C:\IntegrationManager\xslt\date.add.template.xsl"/>
  
  <xsl:output method="xml" indent="yes"/>

  <xsl:template match="/">
    <promotions>
      <xsl:call-template name="campaignLoop">
        <xsl:with-param name="i" select="0"/>
        <xsl:with-param name="beginDate" select="//x:dateToBegin"/>
        <xsl:with-param name="daysToGenerate" select="//x:daysToGenerate"/>
        <xsl:with-param name="daysOfActiveCoupons" select="//x:daysOfActiveCoupons"/>
        <xsl:with-param name="campaignIdFormat" select="//x:campaignIdFormat"/>
        <xsl:with-param name="couponIdFormat" select="//x:couponIdFormat"/>
        <xsl:with-param name="promotionId" select="//x:promotionId"/>
      </xsl:call-template>
      <xsl:call-template name="promotionCampaignAssignmentLoop">
        <xsl:with-param name="i" select="0"/>
        <xsl:with-param name="beginDate" select="//x:dateToBegin"/>
        <xsl:with-param name="daysToGenerate" select="//x:daysToGenerate"/>
        <xsl:with-param name="daysOfActiveCoupons" select="//x:daysOfActiveCoupons"/>
        <xsl:with-param name="campaignIdFormat" select="//x:campaignIdFormat"/>
        <xsl:with-param name="promotionId" select="//x:promotionId"/>
      </xsl:call-template>
    </promotions>  
  </xsl:template>

  <xsl:template name="campaignLoop">
    <xsl:param name="i"/>
    <xsl:param name="beginDate"/>
    <xsl:param name="daysToGenerate"/>
    <xsl:param name="daysOfActiveCoupons"/>
    <xsl:param name="campaignIdFormat"/>
    <xsl:param name="couponIdFormat" />
    <xsl:param name="promotionId"/>
    <xsl:if test="$i &lt; $daysToGenerate">
      <xsl:variable name="newBeginDate">
        <xsl:call-template name="date:add">
          <xsl:with-param name="date-time" select="string($beginDate)"/>
          <xsl:with-param name="duration">P<xsl:value-of select="$i"/>D</xsl:with-param>
        </xsl:call-template>
      </xsl:variable>
      <xsl:variable name="endDate">
        <xsl:call-template name="date:add">
          <xsl:with-param name="date-time" select="string($newBeginDate)"/>
          <xsl:with-param name="duration">P<xsl:value-of select="$daysOfActiveCoupons"/>D</xsl:with-param>
        </xsl:call-template>
      </xsl:variable>
      <campaign>
        <xsl:attribute name="campaign-id">
          <xsl:value-of select="$campaignIdFormat"/>_<xsl:value-of select="$newBeginDate"/>_<xsl:value-of select="$endDate"/>
        </xsl:attribute>
        <description>complimentary free shipping on return</description>
        <enabled-flag>true</enabled-flag>
        <start-date><xsl:call-template name="formatDate"><xsl:with-param name="date" select="$newBeginDate"/></xsl:call-template></start-date>
        <end-date><xsl:call-template name="formatDate"><xsl:with-param name="date" select="$endDate"/></xsl:call-template></end-date>
        <!--customer-groups>
          <customer-group group-id="Everyone"/>
        </customer-groups-->
        <coupons>
          <coupon>
            <xsl:attribute name="coupon-id">
              <xsl:value-of select="$couponIdFormat"/>_<xsl:value-of select="$newBeginDate"/>_<xsl:value-of select="$endDate"/>
            </xsl:attribute>
          </coupon>
        </coupons>
      </campaign>
      <xsl:call-template name="campaignLoop">
        <xsl:with-param name="i">
          <xsl:value-of select="$i + 1"/>
        </xsl:with-param>
        <xsl:with-param name="beginDate" select="$beginDate"/>
        <xsl:with-param name="daysToGenerate" select="$daysToGenerate"/>
        <xsl:with-param name="daysOfActiveCoupons" select="$daysOfActiveCoupons"/>
        <xsl:with-param name="campaignIdFormat" select="$campaignIdFormat"/>
        <xsl:with-param name="couponIdFormat" select="$couponIdFormat"/>
        <xsl:with-param name="promotionId" select="$promotionId"/>
      </xsl:call-template>
    </xsl:if>
  </xsl:template>

  <xsl:template name="promotionCampaignAssignmentLoop">
    <xsl:param name="i"/>
    <xsl:param name="beginDate"/>
    <xsl:param name="daysToGenerate"/>
    <xsl:param name="daysOfActiveCoupons"/>
    <xsl:param name="campaignIdFormat"/>
    <xsl:param name="promotionId"/>
    <xsl:if test="$i &lt; $daysToGenerate">
      <xsl:variable name="newBeginDate">
        <xsl:call-template name="date:add">
          <xsl:with-param name="date-time" select="string($beginDate)"/>
          <xsl:with-param name="duration">P<xsl:value-of select="$i"/>D</xsl:with-param>
        </xsl:call-template>
      </xsl:variable>
      <xsl:variable name="endDate">
        <xsl:call-template name="date:add">
          <xsl:with-param name="date-time" select="string($newBeginDate)"/>
          <xsl:with-param name="duration">P<xsl:value-of select="$daysOfActiveCoupons"/>D</xsl:with-param>
        </xsl:call-template>
      </xsl:variable>
      <promotion-campaign-assignment>
        <xsl:attribute name="promotion-id">
          <xsl:value-of select="$promotionId"/>
        </xsl:attribute>
        <xsl:attribute name="campaign-id">
          <xsl:value-of select="$campaignIdFormat"/>_<xsl:value-of select="$newBeginDate"/>_<xsl:value-of select="$endDate"/>
        </xsl:attribute>
        <qualifiers>
          <customer-groups/>
          <source-codes/>
          <coupons/>
        </qualifiers>
      </promotion-campaign-assignment>
      <xsl:call-template name="promotionCampaignAssignmentLoop">
        <xsl:with-param name="i">
          <xsl:value-of select="$i + 1"/>
        </xsl:with-param>
        <xsl:with-param name="beginDate" select="$beginDate"/>
        <xsl:with-param name="daysToGenerate" select="$daysToGenerate"/>
        <xsl:with-param name="daysOfActiveCoupons" select="$daysOfActiveCoupons"/>
        <xsl:with-param name="campaignIdFormat" select="$campaignIdFormat"/>
        <xsl:with-param name="promotionId" select="$promotionId"/>
      </xsl:call-template>
    </xsl:if>
  </xsl:template>

  <xsl:template name="formatDate"><xsl:param name="date"/><xsl:value-of select="$date"/>T05:00:00.000Z</xsl:template>
  
</xsl:stylesheet>