<?xml version="1.0" encoding="utf-8"?>

<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
  <xsl:output method="xml" indent="yes" encoding="utf-8" />
  <xsl:strip-space elements="*" />
  <xsl:key name="k_ProductListing" match="ProductListing" use="translate(base_style_number/text(), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz')" />
  <xsl:key name="sizeKey" match="ProductSize" use="concat(../../base_style_number, '|', prod_size/@value)" />
  <xsl:key name="widthKey" match="ProductSize" use="concat(../../base_style_number, '|', attribute/@value)" />
  <xsl:key name="styleKey" match="ProductSize" use="concat(../../base_style_number, '|', style_number)" />
  <xsl:key name="upcKey" match="ProductSize" use="concat(../../base_style_number, '|', upc_number)" />
  <xsl:key name="imageGroupKey" match="ProductImage" use="concat(../../base_style_number, '|', @Name)" />
  <xsl:key name="imageKey" match="Image" use="concat(../../../../base_style_number, '|', ../../@Name, '|', @url)" />
  <xsl:variable name="models" select="ArrayOfProductListing/ProductListing[generate-id() = generate-id(key('k_ProductListing', translate(base_style_number/text(), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz'))[1])]" />
  <xsl:variable name="styles" select="ArrayOfProductListing/ProductListing" />
  <xsl:variable name="lower-case">abcdefghijklmnopqrstuvwxyz</xsl:variable>
  <xsl:variable name="upper-case">ABCDEFGHIJKLMNOPQRSTUVWXYZ</xsl:variable>
  <xsl:template match="/">
    <xsl:element name="catalog" namespace="http://www.demandware.com/xml/impex/catalog/2006-10-31">
      <xsl:attribute name="catalog-id">
        <xsl:text>masterCatalog_Warrior</xsl:text>
      </xsl:attribute>
      <xsl:call-template name="master-products" />
      <xsl:call-template name="variant-products" />
    </xsl:element>
  </xsl:template>
  <xsl:template name="master-products">
    <xsl:for-each select="$models">
      <xsl:variable name="model" select="base_style_number/text()" />
      <xsl:variable name="productType" select="DemandwareProductType"/>
      <xsl:element name="product" namespace="http://www.demandware.com/xml/impex/catalog/2006-10-31">
        <xsl:attribute name="product-id">
          <xsl:choose>
            <xsl:when test="$productType = 'Standard'">
              <xsl:value-of select="normalize-space(Sizes/ProductSize[1]/upc_number/text())" disable-output-escaping="yes" />
            </xsl:when>
            <xsl:when test="$productType = 'Master/Variant'">
              <xsl:value-of select="normalize-space(base_style_number/text())" disable-output-escaping="yes" />
            </xsl:when>
          </xsl:choose>
        </xsl:attribute>
        <xsl:call-template name="base-product-info">
          <xsl:with-param name="display-name" select="DisplayName" />
          <!--<xsl:with-param name="long-description" select="long_descrip" />-->
          <!--<xsl:with-param name="short-description" select="long_descrip"/>-->
        </xsl:call-template>
        <xsl:call-template name="PIMmasterOnline"></xsl:call-template>
        <xsl:element name="images" namespace="http://www.demandware.com/xml/impex/catalog/2006-10-31">
          <xsl:variable name="local-styles" select="$styles[base_style_number/text() = concat($model, '')]" />
          <xsl:for-each select="$local-styles">
            <xsl:variable name="image-groups" select="ProductImages/ProductImage" />
            <xsl:for-each select="$image-groups">
              <xsl:element name="image-group" namespace="http://www.demandware.com/xml/impex/catalog/2006-10-31">
                <xsl:if test="$productType = 'Master/Variant'">
                  <xsl:attribute name="variation-value">
                    <xsl:value-of select="../../ColorBucket" disable-output-escaping="yes"/>
                  </xsl:attribute>
                </xsl:if>
                <xsl:attribute name="view-type">
                  <xsl:value-of select="translate(@Name, $upper-case, $lower-case)" />
                </xsl:attribute>
                <xsl:apply-templates select="Images/Image" />
              </xsl:element>
            </xsl:for-each>
          </xsl:for-each>
        </xsl:element>
        <xsl:element name="brand" namespace="http://www.demandware.com/xml/impex/catalog/2006-10-31">
          <xsl:value-of select="BrandName" disable-output-escaping="yes" />
        </xsl:element>
        <!-- custom attributes -->
        <xsl:element name="custom-attributes" namespace="http://www.demandware.com/xml/impex/catalog/2006-10-31">
          <xsl:apply-templates select="long_descrip" />
          <xsl:apply-templates select="Gender" />
          <xsl:apply-templates select="AgeGroup" />
          <xsl:apply-templates select="predecessor_style" />
          <xsl:apply-templates select="successor_style" />
          <xsl:apply-templates select="fit_type" />
          <xsl:apply-templates select="primaryColor" />
          <xsl:apply-templates select="secondaryColor" />
          <xsl:apply-templates select="tertiaryColor" />
          <xsl:apply-templates select="refinementColor" />
          <xsl:apply-templates select="apparelCareTips" />
          <xsl:apply-templates select="tempurature" />
          <xsl:apply-templates select="weight" />
          <!--<xsl:apply-templates select="shoe_last" />-->
          <xsl:apply-templates select="body_type" />
          <xsl:apply-templates select="mileage" />
          <xsl:apply-templates select="arch_type" />
          <xsl:apply-templates select="runningSurface" />
          <xsl:apply-templates select="run_gait" />
          <xsl:apply-templates select="BrandName" />
          <xsl:apply-templates select="primaryCategory" />
          <!--<xsl:apply-templates select="class_type" />-->
          <xsl:apply-templates select="material" />
          <xsl:apply-templates select="descriptiveMaterial" />
          <xsl:apply-templates select="collections" />
          <xsl:apply-templates select="TruncatedStyleNumber" />
          <xsl:apply-templates select="is_map" />
          <!--<xsl:apply-templates select="itemType" />-->
          <xsl:apply-templates select="productTechnologiesList"/>
          <!--<xsl:apply-templates select="features" />-->
          <xsl:apply-templates select="drop_ship" />
          <xsl:apply-templates select="prod_class" />
          <xsl:apply-templates select="MSRP" />
          <xsl:apply-templates select="ProductFeaturesAggregated" />
          <xsl:apply-templates select="sport" />
          <xsl:apply-templates select="eCommerce" />
          <xsl:apply-templates select="blade_pattern" />
          <!--<xsl:apply-templates select="PIMproductOverlay" />-->

          
          <xsl:call-template name="PIMoverlay"></xsl:call-template>

          <xsl:apply-templates select="GenderAndAgeGroup" />
          <xsl:apply-templates select="closeout" />
          <xsl:call-template name="custom-attribute">
            <xsl:with-param name="attribute-name">sourceFeed</xsl:with-param>
            <xsl:with-param name="attribute-value">DIS</xsl:with-param>
          </xsl:call-template>
          <xsl:apply-templates select="product_tax_code" />
          <xsl:if test="$productType = 'Standard'">
            <xsl:call-template name="custom-attribute">
              <xsl:with-param name="attribute-name">styleNumber</xsl:with-param>
              <xsl:with-param name="attribute-value" select="style_number" />
            </xsl:call-template>
          </xsl:if>


          <xsl:call-template name="MasterClearanceFlag"></xsl:call-template>


        </xsl:element>
        <!-- variations -->
        <xsl:if test="$productType = 'Master/Variant'">
          <xsl:element name="variations" namespace="http://www.demandware.com/xml/impex/catalog/2006-10-31">
            <xsl:element name="attributes" namespace="http://www.demandware.com/xml/impex/catalog/2006-10-31">
              <xsl:if test="count($styles[base_style_number/text() = concat($model,'')]/Sizes/ProductSize[generate-id() = generate-id(key('styleKey', concat(../../base_style_number, '|', style_number))[1])]/style_number) &gt; 0 and $styles[base_style_number/text() = concat($model,'')]/Sizes/ProductSize[generate-id() = generate-id(key('styleKey', concat(../../base_style_number, '|', style_number))[1])]/style_number[1] != ''">
                <xsl:element name="variation-attribute" namespace="http://www.demandware.com/xml/impex/catalog/2006-10-31">
                  <xsl:attribute name="variation-attribute-id">color</xsl:attribute>
                  <xsl:attribute name="attribute-id">color</xsl:attribute>
                  <xsl:element name="variation-attribute-values" namespace="http://www.demandware.com/xml/impex/catalog/2006-10-31">
                    <xsl:apply-templates select="$styles[base_style_number/text() = concat($model,'')]/Sizes/ProductSize[generate-id() = generate-id(key('styleKey', concat(../../base_style_number, '|', style_number))[1])]/../../color" />
                  </xsl:element>
                </xsl:element>
              </xsl:if>
              <xsl:if test="count($styles[base_style_number/text() = concat($model,'')]/Sizes/ProductSize[generate-id() = generate-id(key('sizeKey', concat(../../base_style_number, '|', prod_size/@value))[1])]/prod_size) &gt; 0 and $styles[base_style_number/text() = concat($model,'')]/Sizes/ProductSize[generate-id() = generate-id(key('sizeKey', concat(../../base_style_number, '|', prod_size/@value))[1])]/prod_size[1]/@value != ''">
                <xsl:element name="variation-attribute" namespace="http://www.demandware.com/xml/impex/catalog/2006-10-31">
                  <xsl:attribute name="variation-attribute-id">size</xsl:attribute>
                  <xsl:attribute name="attribute-id">size</xsl:attribute>
                  <xsl:element name="variation-attribute-values" namespace="http://www.demandware.com/xml/impex/catalog/2006-10-31">
                    <xsl:apply-templates select="$styles[base_style_number/text() = concat($model,'')]/Sizes/ProductSize[generate-id() = generate-id(key('sizeKey', concat(../../base_style_number, '|', prod_size/@value))[1])]/prod_size">
                      <xsl:sort select="@sort" order="ascending" data-type="number" />
                    </xsl:apply-templates>
                  </xsl:element>
                </xsl:element>
              </xsl:if>
              <xsl:if test="count($styles[base_style_number/text() = concat($model,'')]/Sizes/ProductSize[generate-id() = generate-id(key('widthKey', concat(../../base_style_number, '|', attribute/@value))[1])]/attribute) &gt; 0 and $styles[base_style_number/text() = concat($model,'')]/Sizes/ProductSize[generate-id() = generate-id(key('widthKey', concat(../../base_style_number, '|', attribute/@value))[1])]/attribute[1]/@value != ''">
                <xsl:element name="variation-attribute" namespace="http://www.demandware.com/xml/impex/catalog/2006-10-31">
                  <xsl:attribute name="variation-attribute-id">width</xsl:attribute>
                  <xsl:attribute name="attribute-id">width</xsl:attribute>
                  <xsl:element name="variation-attribute-values" namespace="http://www.demandware.com/xml/impex/catalog/2006-10-31">
                    <xsl:apply-templates select="$styles[base_style_number/text() = concat($model,'')]/Sizes/ProductSize[generate-id() = generate-id(key('widthKey', concat(../../base_style_number, '|', attribute/@value))[1])]/attribute">
                      <xsl:sort select="@sort" order="ascending" data-type="number" />
                    </xsl:apply-templates>
                  </xsl:element>
                </xsl:element>
              </xsl:if>
            </xsl:element>
            <xsl:element name="variants" namespace="http://www.demandware.com/xml/impex/catalog/2006-10-31">
              <xsl:apply-templates select="$styles[base_style_number/text() = concat($model,'')]/Sizes/ProductSize[generate-id() = generate-id(key('upcKey', concat(../../base_style_number, '|', upc_number))[1])]/upc_number">
                <xsl:with-param name="command">variant</xsl:with-param>
              </xsl:apply-templates>
            </xsl:element>
          </xsl:element>
        </xsl:if>
      </xsl:element>
    </xsl:for-each>
  </xsl:template>
  <xsl:template name="variant-products">
    <xsl:apply-templates select="$styles">
      <xsl:with-param name="command">variant-product</xsl:with-param>
    </xsl:apply-templates>
  </xsl:template>
  <xsl:template match="ProductListing">
    <xsl:if test="DemandwareProductType = 'Master/Variant'">
      <xsl:variable name="display-name" select="DisplayName" />
      <xsl:variable name="short-description" select="product_profile" />
      <xsl:variable name="long-description" select="long_descrip" />
      <xsl:variable name="images" select="ProductImages/Image" />
      <xsl:variable name="brand" select="BrandName" />
      <xsl:variable name="variants" select="Sizes/ProductSize" />
      <xsl:for-each select="$variants">
        <xsl:element name="product" namespace="http://www.demandware.com/xml/impex/catalog/2006-10-31">
          <xsl:attribute name="product-id">
            <xsl:value-of select="normalize-space(upc_number)" disable-output-escaping="yes" />
          </xsl:attribute>
          <xsl:call-template name="base-product-info">
            <xsl:with-param name="display-name" select="$display-name" />
            <xsl:with-param name="long-description" select="$long-description" />
            <xsl:with-param name="short-description" select="$short-description" />
          </xsl:call-template>

          <xsl:call-template name="PIMvarOnline"></xsl:call-template>

          <xsl:element name="custom-attributes" namespace="http://www.demandware.com/xml/impex/catalog/2006-10-31">
            <xsl:call-template name="custom-attribute">
              <xsl:with-param name="attribute-name">color</xsl:with-param>
              <xsl:with-param name="attribute-value" select="../../ColorBucket" />
            </xsl:call-template>
            <xsl:call-template name="custom-attribute">
              <xsl:with-param name="attribute-name">size</xsl:with-param>
              <xsl:with-param name="attribute-value" select="prod_size/@value" />
            </xsl:call-template>
            <xsl:call-template name="custom-attribute">
              <xsl:with-param name="attribute-name">width</xsl:with-param>
              <xsl:with-param name="attribute-value" select="attribute/@value" />
            </xsl:call-template>
            <xsl:call-template name="custom-attribute">
              <xsl:with-param name="attribute-name">styleNumber</xsl:with-param>
              <xsl:with-param name="attribute-value" select="../../style_number" />
            </xsl:call-template>

            <xsl:call-template name="ClearanceFlag"></xsl:call-template>
            
            
          </xsl:element>
        </xsl:element>
      </xsl:for-each>
    </xsl:if>
  </xsl:template>
  <xsl:template match="long_descrip">
    <xsl:if test=". != ''">
      <xsl:element name="custom-attribute" namespace="http://www.demandware.com/xml/impex/catalog/2006-10-31">
        <xsl:attribute name="attribute-id">pimLongDescription</xsl:attribute>
        <xsl:call-template name="cdata_start" />
        <xsl:value-of select="." disable-output-escaping="yes" />
        <xsl:call-template name="cdata_end"/>
      </xsl:element>
    </xsl:if>
  </xsl:template>
  <xsl:template match="Gender">
    <xsl:if test=". != ''">
      <xsl:call-template name="custom-attribute">
        <xsl:with-param name="attribute-name">gender</xsl:with-param>
        <xsl:with-param name="attribute-value" select="." />
      </xsl:call-template>
    </xsl:if>
  </xsl:template>
  <xsl:template match="AgeGroup">
    <xsl:if test=". != ''">
      <xsl:call-template name="custom-attribute">
        <xsl:with-param name="attribute-name">ageGroup</xsl:with-param>
        <xsl:with-param name="attribute-value" select="." />
      </xsl:call-template>
    </xsl:if>
  </xsl:template>
  <xsl:template match="predecessor_style">
    <xsl:if test=". != ''">
      <xsl:call-template name="custom-attribute">
        <xsl:with-param name="attribute-name">predecessorStyle</xsl:with-param>
        <xsl:with-param name="attribute-value" select="." />
      </xsl:call-template>
    </xsl:if>
  </xsl:template>
  <xsl:template match="successor_style">
    <xsl:if test=". != ''">
      <xsl:call-template name="custom-attribute">
        <xsl:with-param name="attribute-name">successorStyle</xsl:with-param>
        <xsl:with-param name="attribute-value" select="." />
      </xsl:call-template>
    </xsl:if>
  </xsl:template>
  <xsl:template match="fit_type">
    <xsl:if test=". != ''">
      <xsl:call-template name="custom-attribute">
        <xsl:with-param name="attribute-name">fitType</xsl:with-param>
        <xsl:with-param name="attribute-value" select="." />
      </xsl:call-template>
    </xsl:if>
  </xsl:template>
  <xsl:template match="primaryColor">
    <xsl:if test=". != ''">
      <xsl:call-template name="custom-attribute">
        <xsl:with-param name="attribute-name">primaryColor</xsl:with-param>
        <xsl:with-param name="attribute-value" select="." />
      </xsl:call-template>
    </xsl:if>
  </xsl:template>
  <xsl:template match="secondaryColor">
    <xsl:if test=". != ''">
      <xsl:call-template name="custom-attribute">
        <xsl:with-param name="attribute-name">secondaryColor</xsl:with-param>
        <xsl:with-param name="attribute-value" select="." />
      </xsl:call-template>
    </xsl:if>
  </xsl:template>
  <xsl:template match="tertiaryColor">
    <xsl:if test=". != ''">
      <xsl:call-template name="custom-attribute">
        <xsl:with-param name="attribute-name">tertiaryColor</xsl:with-param>
        <xsl:with-param name="attribute-value" select="." />
      </xsl:call-template>
    </xsl:if>
  </xsl:template>
  <xsl:template match="refinementColor">
    <xsl:if test=". != ''">
      <xsl:call-template name="custom-attribute">
        <xsl:with-param name="attribute-name">refinementColor</xsl:with-param>
        <xsl:with-param name="attribute-value" select="." />
      </xsl:call-template>
    </xsl:if>
  </xsl:template>
  <xsl:template match="apparelCareTips">
    <xsl:element name="custom-attribute" namespace="http://www.demandware.com/xml/impex/catalog/2006-10-31">
      <xsl:attribute name="attribute-id">_ApparelCareTips</xsl:attribute>
      <xsl:for-each select="string">
        <xsl:element name="value" namespace="http://www.demandware.com/xml/impex/catalog/2006-10-31">
          <xsl:value-of select="." disable-output-escaping="yes"/>
        </xsl:element>
      </xsl:for-each>
    </xsl:element>
  </xsl:template>
  <xsl:template match="temperature">
    <xsl:if test=". != ''">
      <xsl:call-template name="custom-attribute">
        <xsl:with-param name="attribute-name">temperature</xsl:with-param>
        <xsl:with-param name="attribute-value" select="." />
      </xsl:call-template>
    </xsl:if>
  </xsl:template>
  <xsl:template match="weight">
    <xsl:if test=". != ''">
      <xsl:call-template name="custom-attribute">
        <xsl:with-param name="attribute-name">descriptiveWeight</xsl:with-param>
        <xsl:with-param name="attribute-value" select="." />
      </xsl:call-template>
    </xsl:if>
  </xsl:template>
  <xsl:template match="shoe_last">
    <xsl:if test=". != ''">
      <xsl:call-template name="custom-attribute">
        <xsl:with-param name="attribute-name">_ShoeLast</xsl:with-param>
        <xsl:with-param name="attribute-value" select="." />
      </xsl:call-template>
    </xsl:if>
  </xsl:template>
  <xsl:template match="body_type">
    <xsl:if test=". != ''">
      <xsl:call-template name="custom-attribute">
        <xsl:with-param name="attribute-name">bodyType</xsl:with-param>
        <xsl:with-param name="attribute-value" select="." />
      </xsl:call-template>
    </xsl:if>
  </xsl:template>
  <xsl:template match="mileage">
    <xsl:if test=". != ''">
      <xsl:call-template name="custom-attribute">
        <xsl:with-param name="attribute-name">mileage</xsl:with-param>
        <xsl:with-param name="attribute-value" select="." />
      </xsl:call-template>
    </xsl:if>
  </xsl:template>
  <xsl:template match="arch_type">
    <xsl:if test=". != ''">
      <xsl:call-template name="custom-attribute">
        <xsl:with-param name="attribute-name">archType</xsl:with-param>
        <xsl:with-param name="attribute-value" select="." />
      </xsl:call-template>
    </xsl:if>
  </xsl:template>
  <xsl:template match="runningSurface">
    <xsl:if test=". != ''">
      <xsl:call-template name="custom-attribute">
        <xsl:with-param name="attribute-name">runningSurface</xsl:with-param>
        <xsl:with-param name="attribute-value" select="." />
      </xsl:call-template>
    </xsl:if>
  </xsl:template>
  <xsl:template match="run_gait">
    <xsl:if test=". != ''">
      <xsl:call-template name="custom-attribute">
        <xsl:with-param name="attribute-name">runGait</xsl:with-param>
        <xsl:with-param name="attribute-value" select="." />
      </xsl:call-template>
    </xsl:if>
  </xsl:template>
  <xsl:template match="BrandName">
    <xsl:if test=". != ''">
      <xsl:call-template name="custom-attribute">
        <xsl:with-param name="attribute-name">brand</xsl:with-param>
        <xsl:with-param name="attribute-value" select="." />
      </xsl:call-template>
    </xsl:if>
  </xsl:template>
  <xsl:template match="primaryCategory">
    <xsl:if test=". != ''">
      <xsl:call-template name="custom-attribute">
        <xsl:with-param name="attribute-name">primaryCategory</xsl:with-param>
        <xsl:with-param name="attribute-value" select="." />
      </xsl:call-template>
    </xsl:if>
  </xsl:template>
  <xsl:template match="class_type">
    <xsl:if test=". != ''">
      <xsl:call-template name="custom-attribute">
        <xsl:with-param name="attribute-name">isCloseout</xsl:with-param>
        <xsl:with-param name="attribute-value" select="." />
      </xsl:call-template>
    </xsl:if>
  </xsl:template>
  <xsl:template match="material">
    <xsl:if test=". != ''">
      <xsl:call-template name="custom-attribute">
        <xsl:with-param name="attribute-name">material</xsl:with-param>
        <xsl:with-param name="attribute-value" select="." />
      </xsl:call-template>
    </xsl:if>
  </xsl:template>
  <xsl:template match="descriptiveMaterial">
    <xsl:if test=". != ''">
      <xsl:call-template name="custom-attribute">
        <xsl:with-param name="attribute-name">descriptiveMaterial</xsl:with-param>
        <xsl:with-param name="attribute-value" select="." />
      </xsl:call-template>
    </xsl:if>
  </xsl:template>
  <xsl:template match="collections">
    <xsl:if test=". != ''">
      <xsl:call-template name="custom-attribute">
        <xsl:with-param name="attribute-name">collection</xsl:with-param>
        <xsl:with-param name="attribute-value" select="." />
      </xsl:call-template>
    </xsl:if>
  </xsl:template>
  <xsl:template match="TruncatedStyleNumber">
    <xsl:if test=". != ''">
      <xsl:call-template name="custom-attribute">
        <xsl:with-param name="attribute-name">model</xsl:with-param>
        <xsl:with-param name="attribute-value" select="." />
      </xsl:call-template>
    </xsl:if>
  </xsl:template>
  <xsl:template match="is_map">
    <xsl:if test=". != ''">
      <xsl:call-template name="custom-attribute">
        <xsl:with-param name="attribute-name">isMap</xsl:with-param>
        <xsl:with-param name="attribute-value" select="." />
      </xsl:call-template>
    </xsl:if>
  </xsl:template>
  <xsl:template name="PIMmasterOnline">
    <xsl:for-each select="DWonSiteStyle">
      <xsl:element name="online-flag" namespace="http://www.demandware.com/xml/impex/catalog/2006-10-31">
        <xsl:if test="@site-id != ''">
          <xsl:attribute name="site-id">
            <xsl:value-of select="@site-id" disable-output-escaping="yes"></xsl:value-of>
          </xsl:attribute>
        </xsl:if>
        <xsl:value-of select="@value" disable-output-escaping="yes"/>
      </xsl:element>
    </xsl:for-each>
  </xsl:template>

  <xsl:template name="PIMvarOnline">
    <xsl:for-each select="DWonSite">
      <xsl:element name="online-flag" namespace="http://www.demandware.com/xml/impex/catalog/2006-10-31">
        <xsl:if test="@site-id != ''">
          <xsl:attribute name="site-id">
            <xsl:value-of select="@site-id" disable-output-escaping="yes"></xsl:value-of>
          </xsl:attribute>
        </xsl:if>
        <xsl:value-of select="@value" disable-output-escaping="yes"/>
      </xsl:element>
    </xsl:for-each>
  </xsl:template>
  <xsl:template match="itemType">
    <xsl:if test=". != ''">
      <xsl:call-template name="custom-attribute">
        <xsl:with-param name="attribute-name">itemType</xsl:with-param>
        <xsl:with-param name="attribute-value" select="." />
      </xsl:call-template>
    </xsl:if>
  </xsl:template>
  <xsl:template match="productTechnologiesList">
    <xsl:element name="custom-attribute" namespace="http://www.demandware.com/xml/impex/catalog/2006-10-31">
      <xsl:attribute name="attribute-id">productTechnologies</xsl:attribute>
      <xsl:for-each select="string">
        <xsl:element name="value" namespace="http://www.demandware.com/xml/impex/catalog/2006-10-31">
          <xsl:value-of select="." disable-output-escaping="yes"/>
        </xsl:element>
      </xsl:for-each>
    </xsl:element>
  </xsl:template>
  <xsl:template match="features">
    <xsl:if test=". != ''">
      <xsl:element name="custom-attribute" namespace="http://www.demandware.com/xml/impex/catalog/2006-10-31">
        <xsl:attribute name="attribute-id">features</xsl:attribute>
        <xsl:call-template name="cdata_start" />
        <xsl:value-of select="." disable-output-escaping="yes" />
        <xsl:call-template name="cdata_end"/>
      </xsl:element>
    </xsl:if>
  </xsl:template>
  <xsl:template match="drop_ship">
    <xsl:if test=". != ''">
      <xsl:call-template name="custom-attribute">
        <xsl:with-param name="attribute-name">IsDropShippable</xsl:with-param>
        <xsl:with-param name="attribute-value" select="." />
      </xsl:call-template>
    </xsl:if>
  </xsl:template>
  <xsl:template match="prod_class">
    <xsl:if test=". != ''">
      <xsl:call-template name="custom-attribute">
        <xsl:with-param name="attribute-name">productClass</xsl:with-param>
        <xsl:with-param name="attribute-value" select="." />
      </xsl:call-template>
    </xsl:if>
  </xsl:template>
  <xsl:template match="MSRP">
    <xsl:if test=". != ''">
      <xsl:call-template name="custom-attribute">
        <xsl:with-param name="attribute-name">retailPrice</xsl:with-param>
        <xsl:with-param name="attribute-value" select="." />
      </xsl:call-template>
    </xsl:if>
  </xsl:template>
  <xsl:template match="ProductFeaturesAggregated">
    <xsl:if test=". != ''">
      <xsl:element name="custom-attribute" namespace="http://www.demandware.com/xml/impex/catalog/2006-10-31">
        <xsl:attribute name="attribute-id">features</xsl:attribute>
        <xsl:call-template name="cdata_start" />
        <xsl:value-of select="." disable-output-escaping="yes" />
        <xsl:call-template name="cdata_end"/>
      </xsl:element>
    </xsl:if>
  </xsl:template>
  <xsl:template match="sport">
    <xsl:if test=". != ''">
      <xsl:call-template name="custom-attribute">
        <xsl:with-param name="attribute-name">sport</xsl:with-param>
        <xsl:with-param name="attribute-value" select="." />
      </xsl:call-template>
    </xsl:if>
  </xsl:template>
  <xsl:template match="eCommerce">
    <xsl:if test=". != ''">
      <xsl:call-template name="custom-attribute">
        <xsl:with-param name="attribute-name">eCommerceProduct</xsl:with-param>
        <xsl:with-param name="attribute-value" select="." />
      </xsl:call-template>
      <xsl:call-template name="custom-attribute">
        <xsl:with-param name="attribute-name">availableForPurchase</xsl:with-param>
        <xsl:with-param name="attribute-value" select="." />
      </xsl:call-template>
    </xsl:if>
  </xsl:template>
  <xsl:template match="product_tax_code">
    <xsl:if test=". != ''">
      <xsl:call-template name="custom-attribute">
        <xsl:with-param name="attribute-name">taxCode</xsl:with-param>
        <xsl:with-param name="attribute-value" select="." />
      </xsl:call-template>
    </xsl:if>
  </xsl:template>
  <xsl:template match="blade_pattern">
    <xsl:if test=". != ''">
      <xsl:call-template name="custom-attribute">
        <xsl:with-param name="attribute-name">patterns</xsl:with-param>
        <xsl:with-param name="attribute-value" select="." />
      </xsl:call-template>
    </xsl:if>
  </xsl:template>
  <xsl:template match="closeout">
    <xsl:if test=". != ''">
      <xsl:call-template name="custom-attribute">
        <xsl:with-param name="attribute-name">isCloseout</xsl:with-param>
        <xsl:with-param name="attribute-value" select="." />
      </xsl:call-template>
    </xsl:if>
  </xsl:template>
  <xsl:template match="PIMproductOverlay">
      <xsl:call-template name="custom-attribute">
        <xsl:with-param name="attribute-name">PIMproductOverlay</xsl:with-param>
        <xsl:with-param name="attribute-value" select="." />
      </xsl:call-template>
  </xsl:template>
  <xsl:template match="GenderAndAgeGroup">
    <xsl:if test=". != ''">
      <xsl:call-template name="custom-attribute">
        <xsl:with-param name="attribute-name">genderAndAgeGroupCombo</xsl:with-param>
        <xsl:with-param name="attribute-value" select="." />
      </xsl:call-template>
    </xsl:if>
  </xsl:template>
  
  <!--***********************************************-->
  <!-- new attributes for February Demandware changes-->


  <xsl:template name="ClearanceFlag">
    <xsl:for-each select="clearance_flag">
      <xsl:element name="custom-attribute" namespace="http://www.demandware.com/xml/impex/catalog/2006-10-31">
        <xsl:attribute name="attribute-id">markedForClearance</xsl:attribute>
        <xsl:if test="@site-id != ''">
          <xsl:attribute name="site-id">
            <xsl:value-of select="@site-id" disable-output-escaping="yes"></xsl:value-of>
          </xsl:attribute>
        </xsl:if>
        <!--this line sets the value to what PIM is sending-->
        <!--<xsl:value-of select="@value" disable-output-escaping="yes"/>-->

        <!--This line sets the value to blank as an override-->
        <xsl:text></xsl:text>
      </xsl:element>
    </xsl:for-each>
  </xsl:template>

  <xsl:template name="MasterClearanceFlag">
    <xsl:for-each select="masterClearanceFlag">
      <xsl:element name="custom-attribute" namespace="http://www.demandware.com/xml/impex/catalog/2006-10-31">
        <xsl:attribute name="attribute-id">masterClearanceFlag</xsl:attribute>
        <xsl:if test="@site-id != ''">
          <xsl:attribute name="site-id">
            <xsl:value-of select="@site-id" disable-output-escaping="yes"></xsl:value-of>
          </xsl:attribute>
        </xsl:if>
        <xsl:value-of select="@value" disable-output-escaping="yes"/>
      </xsl:element>
    </xsl:for-each>
  </xsl:template>
  
  
  <xsl:template name="IsWideWidth">
    <xsl:for-each select="is_wide_width">
      <xsl:element name="custom-attribute" namespace="http://www.demandware.com/xml/impex/catalog/2006-10-31">
        <xsl:attribute name="attribute-id">certonaWideWidth</xsl:attribute>
        <xsl:if test="@site-id != ''">
          <xsl:attribute name="site-id">
            <xsl:value-of select="@site-id" disable-output-escaping="yes"></xsl:value-of>
          </xsl:attribute>
        </xsl:if>
        <xsl:value-of select="@value" disable-output-escaping="yes"/>
      </xsl:element>
    </xsl:for-each>
  </xsl:template> 
  

  <xsl:template name="IsNarrowWidth">
    <xsl:for-each select="is_narrow_width">
      <xsl:element name="custom-attribute" namespace="http://www.demandware.com/xml/impex/catalog/2006-10-31">
        <xsl:attribute name="attribute-id">certonaNarrowWidth</xsl:attribute>
        <xsl:if test="@site-id != ''">
          <xsl:attribute name="site-id">
            <xsl:value-of select="@site-id" disable-output-escaping="yes"></xsl:value-of>
          </xsl:attribute>
        </xsl:if>
        <xsl:value-of select="@value" disable-output-escaping="yes"/>
      </xsl:element>
    </xsl:for-each>
  </xsl:template>


  <xsl:template name="PIMoverlay">
    <xsl:for-each select="PIMoverlay">
      <xsl:element name="custom-attribute" namespace="http://www.demandware.com/xml/impex/catalog/2006-10-31">
        <xsl:attribute name="attribute-id">PIMproductOverlay</xsl:attribute>
        <xsl:if test="@site-id != ''">
          <xsl:attribute name="site-id">
            <xsl:value-of select="@site-id" disable-output-escaping="yes"></xsl:value-of>
          </xsl:attribute>
        </xsl:if>
        <xsl:value-of select="@value" disable-output-escaping="yes"/>
      </xsl:element>
    </xsl:for-each>
  </xsl:template>

  <xsl:template name="FitMessage">
    <xsl:for-each select="fitMessage">
      <xsl:element name="custom-attribute" namespace="http://www.demandware.com/xml/impex/catalog/2006-10-31">
        <xsl:attribute name="attribute-id">apparelFitMessage</xsl:attribute>
        <xsl:if test="@site-id != ''">
          <xsl:attribute name="site-id">
            <xsl:value-of select="@site-id" disable-output-escaping="yes"></xsl:value-of>
          </xsl:attribute>
        </xsl:if>
        <xsl:call-template name="cdata_start" />
        <xsl:value-of select="." disable-output-escaping="yes" />
        <xsl:call-template name="cdata_end"/>        
      </xsl:element>
    </xsl:for-each>
  </xsl:template>

  <xsl:template name="IsCustomizer">
    <xsl:choose>
      <xsl:when test="personalizedCustomized/text() = 'customized'">
        <xsl:element name="custom-attribute" namespace="http://www.demandware.com/xml/impex/catalog/2006-10-31">
          <xsl:attribute name="attribute-id">isCustomizer</xsl:attribute>
          <xsl:text>true</xsl:text>
        </xsl:element>
      </xsl:when>      
    </xsl:choose>
  </xsl:template>

 
  
  <xsl:template match="is_discountable">
    <xsl:if test=". != ''">
      <xsl:call-template name="custom-attribute">
        <xsl:with-param name="attribute-name">isDiscountable</xsl:with-param>
        <xsl:with-param name="attribute-value" select="." />
      </xsl:call-template>
    </xsl:if>
  </xsl:template>
  <xsl:template match="is_lace_up">
    <xsl:if test=". != ''">
      <xsl:call-template name="custom-attribute">
        <xsl:with-param name="attribute-name">isLaceUpForTheCure</xsl:with-param>
        <xsl:with-param name="attribute-value" select="." />
      </xsl:call-template>
    </xsl:if>
  </xsl:template>
  <xsl:template match="is_made_in_usa">
    <xsl:if test=". != ''">
      <xsl:call-template name="custom-attribute">
        <xsl:with-param name="attribute-name">isMadeInTheUSA</xsl:with-param>
        <xsl:with-param name="attribute-value" select="." />
      </xsl:call-template>
    </xsl:if>
  </xsl:template>
  <xsl:template match="is_assembled_in_usa">
    <xsl:if test=". != ''">
      <xsl:call-template name="custom-attribute">
        <xsl:with-param name="attribute-name">isAssembledInTheUSA</xsl:with-param>
        <xsl:with-param name="attribute-value" select="." />
      </xsl:call-template>
    </xsl:if>
  </xsl:template>
  <xsl:template match="map_price">
    <xsl:if test=". != ''">
      <xsl:call-template name="custom-attribute">
        <xsl:with-param name="attribute-name">productMapPrice</xsl:with-param>
        <xsl:with-param name="attribute-value" select="." />
      </xsl:call-template>
    </xsl:if>
  </xsl:template>
  <xsl:template match="personalize_customize_type">
    <xsl:element name="custom-attribute" namespace="http://www.demandware.com/xml/impex/catalog/2006-10-31">
      <xsl:attribute name="attribute-id">productCustomizationType</xsl:attribute>
      <xsl:for-each select="string">
        <xsl:element name="value" namespace="http://www.demandware.com/xml/impex/catalog/2006-10-31">
          <xsl:value-of select="." disable-output-escaping="yes"/>
        </xsl:element>
      </xsl:for-each>
    </xsl:element>
  </xsl:template>
      
  <xsl:template match="custom_json">
    <xsl:if test=". != ''">
      <xsl:element name="custom-attribute" namespace="http://www.demandware.com/xml/impex/catalog/2006-10-31">
        <!--<xsl:attribute name="attribute-id">customizationJSONObject</xsl:attribute>-->
        <xsl:attribute name="attribute-id">jsonPartCodes</xsl:attribute>
        <xsl:value-of select="." disable-output-escaping="yes" />
      </xsl:element>
    </xsl:if>
  </xsl:template>

  <!--*****************************************-->   
  
  <!--WR 03-05-2012-->
  <xsl:template match="apparelFilterFitType">
    <xsl:element name="custom-attribute" namespace="http://www.demandware.com/xml/impex/catalog/2006-10-31">
      <xsl:attribute name="attribute-id">apparelFitType</xsl:attribute>
      <xsl:for-each select="string">
        <xsl:element name="value" namespace="http://www.demandware.com/xml/impex/catalog/2006-10-31">
          <xsl:value-of select="." disable-output-escaping="yes"/>
        </xsl:element>
      </xsl:for-each>
    </xsl:element>
  </xsl:template>

  <xsl:template match="footwearFilterFitType">
    <xsl:element name="custom-attribute" namespace="http://www.demandware.com/xml/impex/catalog/2006-10-31">
      <xsl:attribute name="attribute-id">footwearFitType</xsl:attribute>
      <xsl:for-each select="string">
        <xsl:element name="value" namespace="http://www.demandware.com/xml/impex/catalog/2006-10-31">
          <xsl:value-of select="." disable-output-escaping="yes"/>
        </xsl:element>
      </xsl:for-each>
    </xsl:element>
  </xsl:template>

  <xsl:template match="apparelFilterFeatures">
    <xsl:element name="custom-attribute" namespace="http://www.demandware.com/xml/impex/catalog/2006-10-31">
      <xsl:attribute name="attribute-id">apparelFeatures</xsl:attribute>
      <xsl:for-each select="string">
        <xsl:element name="value" namespace="http://www.demandware.com/xml/impex/catalog/2006-10-31">
          <xsl:value-of select="." disable-output-escaping="yes"/>
        </xsl:element>
      </xsl:for-each>
    </xsl:element>
  </xsl:template>

  <xsl:template match="footwearFilterFeatures">       
    <xsl:element name="custom-attribute" namespace="http://www.demandware.com/xml/impex/catalog/2006-10-31">
      <xsl:attribute name="attribute-id">footwearFeatures</xsl:attribute>
      <xsl:for-each select="string">
        <xsl:element name="value" namespace="http://www.demandware.com/xml/impex/catalog/2006-10-31">
          <xsl:value-of select="." disable-output-escaping="yes"/>
        </xsl:element>
      </xsl:for-each>
    </xsl:element>
  </xsl:template>
  
  <xsl:template match="apparelFilterTechnology">
    <xsl:element name="custom-attribute" namespace="http://www.demandware.com/xml/impex/catalog/2006-10-31">
      <xsl:attribute name="attribute-id">apparelTechnologies</xsl:attribute>
      <xsl:for-each select="string">
        <xsl:element name="value" namespace="http://www.demandware.com/xml/impex/catalog/2006-10-31">
          <xsl:value-of select="." disable-output-escaping="yes"/>
        </xsl:element>
      </xsl:for-each>
    </xsl:element>
  </xsl:template>

  <xsl:template match="footwearFilterTechnology">
    <xsl:element name="custom-attribute" namespace="http://www.demandware.com/xml/impex/catalog/2006-10-31">
      <xsl:attribute name="attribute-id">footwearTechnologies</xsl:attribute>
      <xsl:for-each select="string">
        <xsl:element name="value" namespace="http://www.demandware.com/xml/impex/catalog/2006-10-31">
          <xsl:value-of select="." disable-output-escaping="yes"/>
        </xsl:element>
      </xsl:for-each>
    </xsl:element>
  </xsl:template>
  
  
  <xsl:template match="subCategoryList">
    <xsl:element name="custom-attribute" namespace="http://www.demandware.com/xml/impex/catalog/2006-10-31">
      <xsl:attribute name="attribute-id">PIMSubCategoryData</xsl:attribute>
      <xsl:for-each select="string">
        <xsl:element name="value" namespace="http://www.demandware.com/xml/impex/catalog/2006-10-31">
          <xsl:value-of select="." disable-output-escaping="yes"/>
        </xsl:element>
      </xsl:for-each>
    </xsl:element>
  </xsl:template>
 
  <xsl:template match="genderDisplay">
    <xsl:if test=". != ''">
      <xsl:call-template name="custom-attribute">
        <xsl:with-param name="attribute-name">genderDisplay</xsl:with-param>
        <xsl:with-param name="attribute-value" select="." />
      </xsl:call-template>
    </xsl:if>
  </xsl:template>
  
  <!--************************************************-->
  
  <!--WR 03/20/2012-->

  <xsl:template match="partCodes">
    <xsl:if test=". != ''">
      <xsl:element name="custom-attribute" namespace="http://www.demandware.com/xml/impex/catalog/2006-10-31">
        <xsl:attribute name="attribute-id">partCodes</xsl:attribute>
        <xsl:call-template name="cdata_start" />
        <xsl:value-of select="." disable-output-escaping="yes" />
        <xsl:call-template name="cdata_end"/>
      </xsl:element>
    </xsl:if>
  </xsl:template>
 
  <xsl:template match="screenName">
    <xsl:if test=". != ''">
      <!--<xsl:call-template name="custom-attribute">
        <xsl:with-param name="attribute-name">screenName</xsl:with-param>
        <xsl:with-param name="attribute-value" select="." />
      </xsl:call-template>-->

      <xsl:element name="custom-attribute" namespace="http://www.demandware.com/xml/impex/catalog/2006-10-31">
        <xsl:attribute name="attribute-id">screenName</xsl:attribute>
        <xsl:call-template name="cdata_start" />
        <xsl:value-of select="." disable-output-escaping="yes" />
        <xsl:call-template name="cdata_end"/>
      </xsl:element>

    </xsl:if>
  </xsl:template>
  <xsl:template match="dateCreated">
    <xsl:if test=". != ''">
      <xsl:call-template name="custom-attribute">
        <xsl:with-param name="attribute-name">dateCreated</xsl:with-param>
        <xsl:with-param name="attribute-value" select="." />
      </xsl:call-template>
    </xsl:if>
  </xsl:template>
  <xsl:template match="baseModel">
    <xsl:if test=". != ''">
      <xsl:call-template name="custom-attribute">
        <xsl:with-param name="attribute-name">baseModel</xsl:with-param>
        <xsl:with-param name="attribute-value" select="." />
      </xsl:call-template>
    </xsl:if>
  </xsl:template>
  <xsl:template match="isGallery">
    <xsl:if test=". != ''">
      <xsl:call-template name="custom-attribute">
        <xsl:with-param name="attribute-name">isGallery</xsl:with-param>
        <xsl:with-param name="attribute-value" select="." />
      </xsl:call-template>
    </xsl:if>
  </xsl:template>

  <!--***********************************************-->
  
  <xsl:template name="custom-attribute">
    <xsl:param name="attribute-name" />
    <xsl:param name="attribute-value" />
    <xsl:if test="$attribute-name != ''">
      <xsl:element name="custom-attribute" namespace="http://www.demandware.com/xml/impex/catalog/2006-10-31">
        <xsl:attribute name="attribute-id">
          <xsl:value-of select="$attribute-name" disable-output-escaping="yes" />
        </xsl:attribute>
        <xsl:value-of select="$attribute-value" disable-output-escaping="yes" />
      </xsl:element>
    </xsl:if>
  </xsl:template>
  <xsl:template name="base-product-info">
    <xsl:param name="display-name" />
    <xsl:element name="display-name" namespace="http://www.demandware.com/xml/impex/catalog/2006-10-31">
      <xsl:call-template name="cdata_start" />
      <xsl:value-of select="$display-name" disable-output-escaping="yes" />
      <xsl:call-template name="cdata_end"/>
    </xsl:element>
  </xsl:template>
  <xsl:template match="prod_size">
    <xsl:if test="@value != ''">
      <xsl:element name="variation-attribute-value" namespace="http://www.demandware.com/xml/impex/catalog/2006-10-31">
        <xsl:attribute name="value">
          <xsl:value-of select="@value" disable-output-escaping="yes" />
        </xsl:attribute>
        <display-value xml:lang="x-default" xmlns="http://www.demandware.com/xml/impex/catalog/2006-10-31">
          <xsl:call-template name="cdata_start" />
          <xsl:value-of select="@value" disable-output-escaping="yes" />
          <xsl:call-template name="cdata_end"/>
        </display-value>
        <display-value xml:lang="en-GB" xmlns="http://www.demandware.com/xml/impex/catalog/2006-10-31">
          <xsl:call-template name="cdata_start" />
          <xsl:value-of select="../prod_size_localized/@value" />
          <xsl:call-template name="cdata_end" />
        </display-value>
      </xsl:element>
    </xsl:if>
  </xsl:template>
  <xsl:template match="attribute">
    <xsl:if test="@value != ''">
      <xsl:element name="variation-attribute-value" namespace="http://www.demandware.com/xml/impex/catalog/2006-10-31">
        <xsl:attribute name="value">
          <xsl:value-of select="@value" disable-output-escaping="yes" />
        </xsl:attribute>
        <xsl:element name="display-value" namespace="http://www.demandware.com/xml/impex/catalog/2006-10-31">
          <xsl:value-of select="@value" disable-output-escaping="yes" />
        </xsl:element>
      </xsl:element>
    </xsl:if>
  </xsl:template>
  <xsl:template match="color">
    <xsl:if test=". != ''">
      <xsl:element name="variation-attribute-value" namespace="http://www.demandware.com/xml/impex/catalog/2006-10-31">
        <xsl:attribute name="value">
          <xsl:value-of select="../ColorBucket" disable-output-escaping="yes" />
        </xsl:attribute>
        <xsl:element name="display-value" namespace="http://www.demandware.com/xml/impex/catalog/2006-10-31">
          <xsl:call-template name="cdata_start"/>
          <xsl:value-of select="." />
          <xsl:call-template name="cdata_end"/>
        </xsl:element>
      </xsl:element>
    </xsl:if>
  </xsl:template>
  <xsl:template match="style_number">
    <xsl:if test=". != ''">
      <xsl:element name="variation-attribute-value" namespace="http://www.demandware.com/xml/impex/catalog/2006-10-31">
        <xsl:attribute name="value">
          <xsl:value-of select="." disable-output-escaping="yes" />
        </xsl:attribute>
        <xsl:element name="display-value" namespace="http://www.demandware.com/xml/impex/catalog/2006-10-31">
          <xsl:value-of select="." disable-output-escaping="yes" />
        </xsl:element>
      </xsl:element>
    </xsl:if>
  </xsl:template>
  <xsl:template match="upc_number">
    <xsl:element name="variant" namespace="http://www.demandware.com/xml/impex/catalog/2006-10-31">
      <xsl:attribute name="product-id">
        <xsl:value-of select="normalize-space(.)" disable-output-escaping="yes" />
      </xsl:attribute>
    </xsl:element>
  </xsl:template>
  <xsl:template match="Image">
    <xsl:element name="image" namespace="http://www.demandware.com/xml/impex/catalog/2006-10-31">
      <xsl:attribute name="path">
        <xsl:value-of select="@url" disable-output-escaping="yes" />
      </xsl:attribute>
    </xsl:element>
  </xsl:template>
  <xsl:template name="cdata_start">
    <xsl:text disable-output-escaping="yes"><![CDATA[<![CDATA[]]></xsl:text>
  </xsl:template>
  <xsl:template name="cdata_end">
    <xsl:text disable-output-escaping="yes"><![CDATA[]]]]><![CDATA[>]]></xsl:text>
  </xsl:template>
</xsl:stylesheet>