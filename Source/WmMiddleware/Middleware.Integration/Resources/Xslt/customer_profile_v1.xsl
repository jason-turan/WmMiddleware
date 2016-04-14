<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:csv="csv:csv">
  
  <xsl:output method="text" encoding="utf-8" />
  
  <xsl:strip-space elements="*" />

  <xsl:variable name="delimiter">
    <xsl:text>&#x09;</xsl:text>
  </xsl:variable>
  
  <csv:columns>
    <column>salutation</column>
    <column>title</column>
    <column>first-name</column>
    <column>second-name</column>
    <column>last-name</column>
    <column>suffix</column>
    <column>company-name</column>
    <column>job-title</column>
    <column>email</column>
    <column>phone-home</column>
    <column>phone-business</column>
    <column>phone-mobile</column>
    <column>fax</column>
    <column>birthday</column>
    <column>gender</column>
    <column>creation-date</column>
    <column>last-login-time</column>
    <column>last-visit-time</column>
    <column>preferred-locale</column>
  </csv:columns>

  <xsl:template match="customers">
    <!-- Loop through the columns in order -->
    <xsl:for-each select="customer/profile">
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
      <xsl:value-of select="job-title"/>
      <xsl:value-of select="$delimiter"/>
      <xsl:value-of select="email"/>
      <xsl:value-of select="$delimiter"/>
      <xsl:value-of select="phone-home"/>
      <xsl:value-of select="$delimiter"/>
      <xsl:value-of select="phone-business"/>
      <xsl:value-of select="$delimiter"/>
      <xsl:value-of select="phone-mobile"/>
      <xsl:value-of select="$delimiter"/>
      <xsl:value-of select="fax"/>
      <xsl:value-of select="$delimiter"/>
      <xsl:value-of select="birthday"/>
      <xsl:value-of select="$delimiter"/>
      <xsl:value-of select="gender"/>
      <xsl:value-of select="$delimiter"/>
      <xsl:value-of select="creation-date"/>
      <xsl:value-of select="$delimiter"/>
      <xsl:value-of select="last-login-time"/>
      <xsl:value-of select="$delimiter"/>
      <xsl:value-of select="last-visit-time"/>
      <xsl:value-of select="$delimiter"/>
      <xsl:value-of select="preferred-locale"/>
      <xsl:value-of select="$delimiter"/>
      <xsl:text>&#xD;</xsl:text>
    </xsl:for-each>
  </xsl:template>
  
	<xsl:template match="customersX/customerX">
			<xsl:apply-templates select="profile"/>
	</xsl:template>
	
	<xsl:template match="profileX">
		<xsl:apply-templates select="custom-attributes"/>
	</xsl:template>
	
	<xsl:template match="custom-attributes">
    <xsl:for-each select="custom-attribute">
      <xsl:choose>
        <xsl:when test="@attribute-id='activities'">
          <!--activity:<xsl:value-of select="."/>,-->
          activity:<xsl:for-each select="value">
            <xsl:value-of select="."/>|
          </xsl:for-each>
        </xsl:when>
        <xsl:when test="@attribute-id='shoeAttributes'">
          shoeAttributes:
          <xsl:for-each select="value">
            <xsl:value-of select="."/>|
          </xsl:for-each>
        </xsl:when>
        <xsl:otherwise>
          <xsl:value-of select="@attribute-id" />:<xsl:value-of select="." />,
        </xsl:otherwise>
      </xsl:choose>
    </xsl:for-each>
	</xsl:template>
	
	<xsl:template match="custom-attribute">
		<xsl:value-of select="@attribute-id" />:
    <xsl:choose>
      <xsl:when test="@attribute-id='activities'">
        <xsl:value-of select="."/>
      </xsl:when>
    </xsl:choose>
  </xsl:template>

	
	
</xsl:stylesheet>
