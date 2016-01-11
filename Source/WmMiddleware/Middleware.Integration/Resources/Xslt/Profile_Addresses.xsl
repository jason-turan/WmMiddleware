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
    <xsl:text>email</xsl:text>
    <xsl:value-of select="$delimiter"/>
    <xsl:text>address-id</xsl:text>
    <xsl:value-of select="$delimiter"/>
    <xsl:text>preferred</xsl:text>
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
    <xsl:text>address1</xsl:text>
    <xsl:value-of select="$delimiter"/>
    <xsl:text>address2</xsl:text>
    <xsl:value-of select="$delimiter"/>
    <xsl:text>suite</xsl:text>
    <xsl:value-of select="$delimiter"/>
    <xsl:text>postbox</xsl:text>
    <xsl:value-of select="$delimiter"/>
    <xsl:text>city</xsl:text>
    <xsl:value-of select="$delimiter"/>
    <xsl:text>postal-code</xsl:text>
    <xsl:value-of select="$delimiter"/>
    <xsl:text>state-code</xsl:text>
    <xsl:value-of select="$delimiter"/>
    <xsl:text>country-code</xsl:text>
    <xsl:value-of select="$delimiter"/>
    <xsl:text>phone</xsl:text>
    <xsl:text>&#xD;</xsl:text>
    
    <xsl:for-each select="doc:customer">
      
      <xsl:variable name="customerNo">
        <xsl:value-of select="@customer-no"/>
      </xsl:variable>

      <xsl:variable name="email">
        <xsl:value-of select="doc:profile/doc:email"/>
      </xsl:variable>

      <xsl:for-each select="doc:addresses/doc:address">
        <xsl:value-of select="$customerNo"/>
        <xsl:value-of select="$delimiter"/>
        <xsl:value-of select="$email"/>
        <xsl:value-of select="$delimiter"/>
        <xsl:value-of select="@address-id"/>
        <xsl:value-of select="$delimiter"/>
        <xsl:value-of select="@preferred"/>
        <xsl:value-of select="$delimiter"/>
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
        <xsl:value-of select="doc:address1"/>
        <xsl:value-of select="$delimiter"/>
        <xsl:value-of select="doc:address2"/>
        <xsl:value-of select="$delimiter"/>
        <xsl:value-of select="doc:suite"/>
        <xsl:value-of select="$delimiter"/>
        <xsl:value-of select="doc:postbox"/>
        <xsl:value-of select="$delimiter"/>
        <xsl:value-of select="doc:city"/>
        <xsl:value-of select="$delimiter"/>
        <xsl:value-of select="doc:postal-code"/>
        <xsl:value-of select="$delimiter"/>
        <xsl:value-of select="doc:state-code"/>
        <xsl:value-of select="$delimiter"/>
        <xsl:value-of select="doc:country-code"/>
        <xsl:value-of select="$delimiter"/>
        <xsl:value-of select="doc:phone"/>
        <xsl:text>&#xD;</xsl:text>
      </xsl:for-each>
      
      <!--<xsl:apply-templates select="doc:addresses">
        <xsl:with-param name="customer-no" select=""
      </xsl:apply-templates>-->
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
