<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:csv="csv:csv">
  
  <xsl:output method="text" encoding="utf-16" />
  
  <xsl:strip-space elements="*" />

  <xsl:variable name="showMultis">
    <xsl:text>true</xsl:text>
  </xsl:variable>
  
  <xsl:variable name="delimiter">
    <xsl:text>&#x09;</xsl:text>
  </xsl:variable>


  <xsl:template match="customers">
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
    
    <xsl:for-each select="customer">
      
      <xsl:variable name="customerNo">
        <xsl:value-of select="@customer-no"/>
      </xsl:variable>

      <xsl:variable name="email">
        <xsl:value-of select="profile/email"/>
      </xsl:variable>

      <xsl:for-each select="addresses/address">
        <xsl:value-of select="$customerNo"/>
        <xsl:value-of select="$delimiter"/>
        <xsl:value-of select="$email"/>
        <xsl:value-of select="$delimiter"/>
        <xsl:value-of select="@address-id"/>
        <xsl:value-of select="$delimiter"/>
        <xsl:value-of select="@preferred"/>
        <xsl:value-of select="$delimiter"/>
        <xsl:value-of select="salutation"/>
        <xsl:value-of select="$delimiter"/>
        <xsl:value-of select="title"/>
        <xsl:value-of select="$delimiter"/>
        <xsl:value-of select="first-name"/>
        <xsl:value-of select="$delimiter"/>
        <xsl:value-of select="second-name"/>
        <xsl:value-of select="$delimiter"/>
        <xsl:value-of select="last-name"/>
        <xsl:value-of select="$delimiter"/>
        <xsl:value-of select="suffix"/>
        <xsl:value-of select="$delimiter"/>
        <xsl:value-of select="company-name"/>
        <xsl:value-of select="$delimiter"/>
        <xsl:value-of select="job-title"/>
        <xsl:value-of select="$delimiter"/>
        <xsl:value-of select="address1"/>
        <xsl:value-of select="$delimiter"/>
        <xsl:value-of select="address2"/>
        <xsl:value-of select="$delimiter"/>
        <xsl:value-of select="suite"/>
        <xsl:value-of select="$delimiter"/>
        <xsl:value-of select="postbox"/>
        <xsl:value-of select="$delimiter"/>
        <xsl:value-of select="city"/>
        <xsl:value-of select="$delimiter"/>
        <xsl:value-of select="postal-code"/>
        <xsl:value-of select="$delimiter"/>
        <xsl:value-of select="state-code"/>
        <xsl:value-of select="$delimiter"/>
        <xsl:value-of select="country-code"/>
        <xsl:value-of select="$delimiter"/>
        <xsl:value-of select="phone"/>
        <xsl:text>&#xD;</xsl:text>
      </xsl:for-each>
      
      <!--<xsl:apply-templates select="addresses">
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
  

  
</xsl:stylesheet>
