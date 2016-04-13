<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:csv="csv:csv" xmlns:doc="http://www.demandware.com/xml/impex/customer/2006-10-31">
  
  <xsl:output method="text" encoding="utf-16" />
  
  <xsl:strip-space elements="*" />

  <xsl:variable name="showMultis">
    <xsl:text>true</xsl:text>
  </xsl:variable>
  
  <xsl:variable name="delimiter">
    <xsl:text>&#x09;</xsl:text>
  </xsl:variable>


  <xsl:template match="doc:customers">
    <!-- Loop through the columns in order -->
    <xsl:text>customer-no</xsl:text>
    <xsl:value-of select="$delimiter"/>
    <xsl:text>salutation</xsl:text>
    <xsl:value-of select="$delimiter"/>
    <xsl:text>title</xsl:text>
    <xsl:value-of select="$delimiter"/>
    <xsl:text>first-name</xsl:text>
    <xsl:value-of select="$delimiter"/>
    <xsl:text>second-name</xsl:text>
    <xsl:value-of select="$delimiter"/>
    <xsl:text>last-name</xsl:text>
    <xsl:value-of select="$delimiter"/>
    <xsl:text>suffix</xsl:text>
    <xsl:value-of select="$delimiter"/>
    <xsl:text>company-name</xsl:text>
    <xsl:value-of select="$delimiter"/>
    <xsl:text>job-title</xsl:text>
    <xsl:value-of select="$delimiter"/>
    <xsl:text>email</xsl:text>
    <xsl:value-of select="$delimiter"/>
    <xsl:text>phone-home</xsl:text>
    <xsl:value-of select="$delimiter"/>
    <xsl:text>phone-business</xsl:text>
    <xsl:value-of select="$delimiter"/>
    <xsl:text>phone-mobile</xsl:text>
    <xsl:value-of select="$delimiter"/>
    <xsl:text>fax</xsl:text>
    <xsl:value-of select="$delimiter"/>
    <xsl:text>birthday</xsl:text>
    <xsl:value-of select="$delimiter"/>
    <xsl:text>gender</xsl:text>
    <xsl:value-of select="$delimiter"/>
    <xsl:text>creation-date</xsl:text>
    <xsl:value-of select="$delimiter"/>
    <xsl:text>last-login-time</xsl:text>
    <xsl:value-of select="$delimiter"/>
    <xsl:text>last-visit-time</xsl:text>
    <xsl:value-of select="$delimiter"/>
    <xsl:text>preferred-locale</xsl:text>
    <xsl:value-of select="$delimiter"/>
    <xsl:text>GMPAlllotmentGiftCardNumber</xsl:text>
    <xsl:value-of select="$delimiter"/>
    <xsl:text>GMPEmail</xsl:text>
    <xsl:value-of select="$delimiter"/>
    <xsl:text>GMPExpiredDate</xsl:text>
    <xsl:value-of select="$delimiter"/>
    <xsl:text>GMPID</xsl:text>
    <xsl:value-of select="$delimiter"/>
    <xsl:text>bvDisplayName</xsl:text>
    <xsl:value-of select="$delimiter"/>
    <xsl:text>haveKids</xsl:text>
    <xsl:value-of select="$delimiter"/>
    <xsl:text>hoursWorkOut</xsl:text>
    <xsl:value-of select="$delimiter"/>
    <xsl:text>initialLogin</xsl:text>
    <xsl:value-of select="$delimiter"/>
    <xsl:text>milesRun</xsl:text>
    <xsl:value-of select="$delimiter"/>
    <xsl:text>milesWalked</xsl:text>
    <xsl:value-of select="$delimiter"/>
    <xsl:text>mobileNumber</xsl:text>
    <xsl:value-of select="$delimiter"/>
    <xsl:text>pantSize</xsl:text>
    <xsl:value-of select="$delimiter"/>
    <xsl:text>profilePicture</xsl:text>
    <xsl:value-of select="$delimiter"/>
    <xsl:text>registrationPostalCode</xsl:text>
    <xsl:value-of select="$delimiter"/>
    <xsl:text>screenName</xsl:text>
    <xsl:value-of select="$delimiter"/>
    <xsl:text>shirtSize</xsl:text>
    <xsl:value-of select="$delimiter"/>
    <xsl:text>shoeSize</xsl:text>
    <xsl:value-of select="$delimiter"/>
    <xsl:text>shoeWidth</xsl:text>
    <xsl:value-of select="$delimiter"/>
    <xsl:text>shopFrequency</xsl:text>
    <xsl:value-of select="$delimiter"/>
    <xsl:text>taxExemptID</xsl:text>
    <xsl:if test="$showMultis='true'">
      <xsl:value-of select="$delimiter"/>
      <xsl:text>activities</xsl:text>
      <xsl:value-of select="$delimiter"/>
      <xsl:text>brandPreference</xsl:text>
      <xsl:value-of select="$delimiter"/>
      <xsl:text>categories</xsl:text>
      <xsl:value-of select="$delimiter"/>
      <xsl:text>shoeAttributes</xsl:text>
      <xsl:value-of select="$delimiter"/>
      <xsl:text>sportPreference</xsl:text>
      <xsl:value-of select="$delimiter"/>
    </xsl:if>
    <xsl:text>&#xD;</xsl:text>
    <xsl:for-each select="doc:customer">
      <xsl:value-of select="@customer-no"/>
      <xsl:value-of select="$delimiter"/>
      <xsl:apply-templates select="doc:profile"/>
    </xsl:for-each>
  </xsl:template>

  <!--
  List of Multi Attributes:
  activities
  brandPreference
  categories
  shoeAttributes
  sportPreference
  -->
  
  <xsl:template match="doc:profile">
    <xsl:value-of select="doc:salutation"/>
    <xsl:value-of select="$delimiter"/>
    <xsl:value-of select="doc:title"/>
    <xsl:value-of select="$delimiter"/>
    <xsl:value-of select="doc:first-name"/>
    <xsl:value-of select="$delimiter"/>
    <xsl:value-of select="doc:second-name"/>
    <xsl:value-of select="$delimiter"/>
    <xsl:value-of select="doc:last-name"/>
    <xsl:value-of select="$delimiter"/>
    <xsl:value-of select="doc:suffix"/>
    <xsl:value-of select="$delimiter"/>
    <xsl:value-of select="doc:company-name"/>
    <xsl:value-of select="$delimiter"/>
    <xsl:value-of select="doc:job-title"/>
    <xsl:value-of select="$delimiter"/>
    <xsl:value-of select="doc:email"/>
    <xsl:value-of select="$delimiter"/>
    <xsl:value-of select="doc:phone-home"/>
    <xsl:value-of select="$delimiter"/>
    <xsl:value-of select="doc:phone-business"/>
    <xsl:value-of select="$delimiter"/>
    <xsl:value-of select="doc:phone-mobile"/>
    <xsl:value-of select="$delimiter"/>
    <xsl:value-of select="doc:fax"/>
    <xsl:value-of select="$delimiter"/>
    <xsl:value-of select="doc:birthday"/>
    <xsl:value-of select="$delimiter"/>
    <xsl:value-of select="doc:gender"/>
    <xsl:value-of select="$delimiter"/>
    <xsl:value-of select="doc:creation-date"/>
    <xsl:value-of select="$delimiter"/>
    <xsl:value-of select="doc:last-login-time"/>
    <xsl:value-of select="$delimiter"/>
    <xsl:value-of select="doc:last-visit-time"/>
    <xsl:value-of select="$delimiter"/>
    <xsl:value-of select="doc:preferred-locale"/>
    <xsl:value-of select="$delimiter"/>
    <xsl:choose>
      <xsl:when test="doc:custom-attributes">
        <xsl:apply-templates select="doc:custom-attributes"/>
      </xsl:when>
      <xsl:otherwise>
        <xsl:value-of select="$delimiter"/>
        <xsl:value-of select="$delimiter"/>
        <xsl:value-of select="$delimiter"/>
        <xsl:value-of select="$delimiter"/>
        <xsl:value-of select="$delimiter"/>
        <xsl:value-of select="$delimiter"/>
        <xsl:value-of select="$delimiter"/>
        <xsl:value-of select="$delimiter"/>
        <xsl:value-of select="$delimiter"/>
        <xsl:value-of select="$delimiter"/>
        <xsl:value-of select="$delimiter"/>
        <xsl:value-of select="$delimiter"/>
        <xsl:value-of select="$delimiter"/>
        <xsl:value-of select="$delimiter"/>
        <xsl:value-of select="$delimiter"/>
        <xsl:value-of select="$delimiter"/>
        <xsl:value-of select="$delimiter"/>
        <xsl:value-of select="$delimiter"/>
        <xsl:value-of select="$delimiter"/>
        <xsl:if test="$showMultis='true'">
          <xsl:value-of select="$delimiter"/>
          <xsl:value-of select="$delimiter"/>
          <xsl:value-of select="$delimiter"/>
          <xsl:value-of select="$delimiter"/>
          <xsl:value-of select="$delimiter"/>
        </xsl:if>
        </xsl:otherwise>
    </xsl:choose>
    <xsl:text>&#xD;</xsl:text>
  </xsl:template>


  <xsl:template match="doc:custom-attributes">
    <xsl:value-of select="doc:custom-attribute[@attribute-id='GMPAlllotmentGiftCardNumber']"></xsl:value-of>
    <xsl:value-of select="$delimiter"/>
    <xsl:value-of select="doc:custom-attribute[@attribute-id='GMPEmail']"></xsl:value-of>
    <xsl:value-of select="$delimiter"/>
    <xsl:value-of select="doc:custom-attribute[@attribute-id='GMPExpiredDate']"></xsl:value-of>
    <xsl:value-of select="$delimiter"/>
    <xsl:value-of select="doc:custom-attribute[@attribute-id='GMPID']"></xsl:value-of>
    <xsl:value-of select="$delimiter"/>
    <xsl:value-of select="doc:custom-attribute[@attribute-id='bvDisplayName']"></xsl:value-of>
    <xsl:value-of select="$delimiter"/>
    <xsl:value-of select="doc:custom-attribute[@attribute-id='haveKids']"></xsl:value-of>
    <xsl:value-of select="$delimiter"/>
    <xsl:value-of select="doc:custom-attribute[@attribute-id='hoursWorkOut']"></xsl:value-of>
    <xsl:value-of select="$delimiter"/>
    <xsl:value-of select="doc:custom-attribute[@attribute-id='initialLogin']"></xsl:value-of>
    <xsl:value-of select="$delimiter"/>
    <xsl:value-of select="doc:custom-attribute[@attribute-id='milesRun']"></xsl:value-of>
    <xsl:value-of select="$delimiter"/>
    <xsl:value-of select="doc:custom-attribute[@attribute-id='milesWalked']"></xsl:value-of>
    <xsl:value-of select="$delimiter"/>
    <xsl:value-of select="doc:custom-attribute[@attribute-id='mobileNumber']"></xsl:value-of>
    <xsl:value-of select="$delimiter"/>
    <xsl:value-of select="doc:custom-attribute[@attribute-id='pantSize']"></xsl:value-of>
    <xsl:value-of select="$delimiter"/>
    <xsl:value-of select="doc:custom-attribute[@attribute-id='profilePicture']"></xsl:value-of>
    <xsl:value-of select="$delimiter"/>
    <xsl:value-of select="doc:custom-attribute[@attribute-id='registrationPostalCode']"></xsl:value-of>
    <xsl:value-of select="$delimiter"/>
    <xsl:value-of select="doc:custom-attribute[@attribute-id='screenName']"></xsl:value-of>
    <xsl:value-of select="$delimiter"/>
    <xsl:value-of select="doc:custom-attribute[@attribute-id='shirtSize']"></xsl:value-of>
    <xsl:value-of select="$delimiter"/>
    <xsl:value-of select="doc:custom-attribute[@attribute-id='shoeSize']"></xsl:value-of>
    <xsl:value-of select="$delimiter"/>
    <xsl:value-of select="doc:custom-attribute[@attribute-id='shoeWidth']"></xsl:value-of>
    <xsl:value-of select="$delimiter"/>
    <xsl:value-of select="doc:custom-attribute[@attribute-id='shopFrequency']"></xsl:value-of>
    <xsl:value-of select="$delimiter"/>
    <xsl:value-of select="doc:custom-attribute[@attribute-id='taxExemptID']"></xsl:value-of>
    <xsl:if test="$showMultis='true'">
      <xsl:value-of select="$delimiter"/>
      <xsl:apply-templates select="doc:custom-attribute[@attribute-id='activities']"></xsl:apply-templates>
      <xsl:value-of select="$delimiter"/>
      <xsl:apply-templates select="doc:custom-attribute[@attribute-id='brandPreference']"></xsl:apply-templates>
      <xsl:value-of select="$delimiter"/>
      <xsl:apply-templates select="doc:custom-attribute[@attribute-id='categories']"></xsl:apply-templates>
      <xsl:value-of select="$delimiter"/>
      <xsl:apply-templates select="doc:custom-attribute[@attribute-id='shoeAttributes']"></xsl:apply-templates>
      <xsl:value-of select="$delimiter"/>
      <xsl:apply-templates select="doc:custom-attribute[@attribute-id='sportPreference']"></xsl:apply-templates>
    </xsl:if>
  </xsl:template>

  <xsl:template match="doc:custom-attribute[@attribute-id='activities']">
    <xsl:for-each select="doc:value">
      <xsl:value-of select="."/>
      <xsl:if test="not(position() = last())">
        <xsl:text>|</xsl:text>
      </xsl:if>
    </xsl:for-each>
  </xsl:template>

  <xsl:template match="doc:custom-attribute[@attribute-id='brandPreference']">
    <xsl:for-each select="doc:value">
      <xsl:value-of select="."/>
      <xsl:if test="not(position() = last())">
        <xsl:text>|</xsl:text>
      </xsl:if>
    </xsl:for-each>
  </xsl:template>

  <xsl:template match="doc:custom-attribute[@attribute-id='categories']">
    <xsl:for-each select="doc:value">
      <xsl:value-of select="."/>
      <xsl:if test="not(position() = last())">
        <xsl:text>|</xsl:text>
      </xsl:if>
    </xsl:for-each>
  </xsl:template>

  <xsl:template match="doc:custom-attribute[@attribute-id='shoeAttributes']">
    <xsl:for-each select="doc:value">
      <xsl:value-of select="."/>
      <xsl:if test="not(position() = last())">
        <xsl:text>|</xsl:text>
      </xsl:if>
    </xsl:for-each>
  </xsl:template>

  <xsl:template match="doc:custom-attribute[@attribute-id='sportPreference']">
    <xsl:for-each select="doc:value">
      <xsl:value-of select="."/>
      <xsl:if test="not(position() = last())">
        <xsl:text>|</xsl:text>
      </xsl:if>
    </xsl:for-each>
  </xsl:template>
  
  <!--
  List of Multi Attributes:
  activities
  brandPreference
  categories
  shoeAttributes
  sportPreference
  -->
  
  <xsl:template match="custom-attributes">
  
  </xsl:template>
  
</xsl:stylesheet>
