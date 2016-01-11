<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0"
				xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
				xmlns:x="http://schemas.datacontract.org/2004/07/WarriorDataFeed.Entities"
				xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl x"
>
	<xsl:output method="xml" indent="yes"/>

	<xsl:strip-space elements="*"/>

	<xsl:key name="by-upc" match="x:Pricebook" use="normalize-space(x:upc_number/text())"/>

	<xsl:template match="/">
		<xsl:element name="pricebooks" namespace="http://www.demandware.com/xml/impex/pricebook/2006-10-31">
			<xsl:element name="pricebook" namespace="http://www.demandware.com/xml/impex/pricebook/2006-10-31">
				<xsl:element name="header" namespace="http://www.demandware.com/xml/impex/pricebook/2006-10-31">
					<xsl:attribute name="pricebook-id">
						<xsl:text>retailPriceBook_Warrior_US</xsl:text>
					</xsl:attribute>
					<xsl:element name="currency" namespace="http://www.demandware.com/xml/impex/pricebook/2006-10-31">
						<xsl:text>USD</xsl:text>
					</xsl:element>
				</xsl:element>
				<xsl:element name="price-tables" namespace="http://www.demandware.com/xml/impex/pricebook/2006-10-31">
					<xsl:apply-templates select="x:ArrayOfPricebook/x:Pricebook[generate-id() = generate-id(key('by-upc', normalize-space(x:upc_number/text()))[1])]"/>
				</xsl:element>
			</xsl:element>
		</xsl:element>
	</xsl:template>

	<xsl:template match="x:Pricebook">
		<xsl:element name="price-table" namespace="http://www.demandware.com/xml/impex/pricebook/2006-10-31">
			<xsl:attribute name="product-id">
				<xsl:value-of select="normalize-space(x:upc_number)"/>
			</xsl:attribute>
			<xsl:element name="amount" namespace="http://www.demandware.com/xml/impex/pricebook/2006-10-31">
				<xsl:attribute name="quantity">
					<xsl:text>1.0</xsl:text>
				</xsl:attribute>
				<xsl:value-of select="normalize-space(x:price)"/>
			</xsl:element>
		</xsl:element>
	</xsl:template>

</xsl:stylesheet>