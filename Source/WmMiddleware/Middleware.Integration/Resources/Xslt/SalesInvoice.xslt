<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt"   exclude-result-prefixes="msxsl"
 >
    <xsl:output method="xml" indent="yes" standalone="yes"/>

  <xsl:key name="k_docnumber" match="Table" use="docnumber/text()" />

  <xsl:variable name="orders" select="NewDataSet/Table[generate-id() = generate-id(key('k_docnumber', docnumber/text())[1])]" />
  <xsl:variable name="lines" select="NewDataSet/Table"/>
  
  
  <!--this is the company key id used by GP-->
  <!--<xsl:variable name="company_key_id" select="'3'"/>-->
  
  <xsl:template match="/">
    <Objects>
      <xsl:call-template name="orders"/>
    </Objects>
  </xsl:template>

  <xsl:template name="orders">
    <xsl:for-each select="$orders">
      <xsl:variable name="docnumber" select="docnumber/text()" />
      <SalesInvoice xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">

        <record_id>
          <xsl:value-of select="$docnumber"/>
        </record_id>

        <trans_type>
          <xsl:value-of select="order_return"/>
        </trans_type>
        
        <BatchKey xmlns="http://schemas.microsoft.com/dynamics/gp/2006/01">
          <CompanyKey>
            <Id xmlns="http://schemas.microsoft.com/dynamics/2006/01">
              <xsl:value-of select="company_key_id"/>
            </Id>
          </CompanyKey>
          <Source>            
            <xsl:value-of select="batch_source"/>
          </Source>
          <Id>            
            <xsl:value-of select="batch_id"/>
          </Id>
          <CreatedDateTime>            
            <xsl:value-of select="batch_create_dt"/>
          </CreatedDateTime>
        </BatchKey>
        
        <Key  xmlns="http://schemas.microsoft.com/dynamics/gp/2006/01">
          <CompanyKey xmlns="http://schemas.microsoft.com/dynamics/gp/2006/01">
              <Id   xmlns="http://schemas.microsoft.com/dynamics/gp/2006/01">
                <xsl:value-of select="company_key_id"/>                
              </Id>
            </CompanyKey>
          <Id>
            <xsl:value-of select="docnumber"/>
          </Id>
        </Key>

        
        <xsl:if test="comment">
          <Comment xmlns="http://schemas.microsoft.com/dynamics/gp/2006/01">
            <xsl:value-of select="comment"/>
          </Comment>
        </xsl:if>
        

        <xsl:if test="shipmethod">
          <ShippingMethodKey xmlns="http://schemas.microsoft.com/dynamics/gp/2006/01">
            <CompanyKey>
              <Id xmlns="http://schemas.microsoft.com/dynamics/2006/01">
                <xsl:value-of select="company_key_id"/>
              </Id>
            </CompanyKey>
            <Id>
              <xsl:value-of select="ship_method"/>
              <!--<xsl:text>USPS</xsl:text>-->
            </Id>
          </ShippingMethodKey>
        </xsl:if>

        <xsl:if test="sum_shipcost">
          <FreightAmount xmlns="http://schemas.microsoft.com/dynamics/gp/2006/01">
            <Currency>USD</Currency>
            <Value>
              <xsl:value-of select="sum_shipcost"/>
            </Value>
            <DecimalDigits>2</DecimalDigits>
          </FreightAmount>
        </xsl:if>


        <!--<xsl:if test="use_sum_credit_payment = 'false'">-->
        <!--<xsl:if test="second_payment = 'false'">-->        
          <TradeDiscount xmlns="http://schemas.microsoft.com/dynamics/gp/2006/01">
            <Amount>
              <Currency>USD</Currency>
              <Value>                
                <xsl:value-of select="sum_coupon_amount"/>
              </Value>
              <DecimalDigits>2</DecimalDigits>
            </Amount>
          </TradeDiscount>          
        <!--</xsl:if>-->
        

        <Taxes xmlns="http://schemas.microsoft.com/dynamics/gp/2006/01">
          <SalesDocumentTax>
            <TaxAmount>
              <Currency>USD</Currency>
              <Value>
                <xsl:value-of select="sum_taxamount"/>
              </Value>
              <DecimalDigits>2</DecimalDigits>
            </TaxAmount>
            <TaxableAmount>
              <Currency>USD</Currency>
              <Value>
                <xsl:value-of select="sum_subtotal"/>
              </Value>
              <DecimalDigits>2</DecimalDigits>
            </TaxableAmount>

            <IsBackoutTax xsi:nil="true" />
            <IsTaxableTax xsi:nil="true" />
            <Key>
              <CompanyKey>
                <Id xmlns="http://schemas.microsoft.com/dynamics/2006/01">
                  <xsl:value-of select="company_key_id"/>
                </Id>
              </CompanyKey>              
              
              <TaxDetailKey>
                <CompanyKey>
                  <Id xmlns="http://schemas.microsoft.com/dynamics/2006/01">
                    <xsl:value-of select="company_key_id"/>
                  </Id>
                </CompanyKey>
                <Id>NOTAX</Id>
              </TaxDetailKey>
              
            </Key>
          </SalesDocumentTax>
        </Taxes>

        <Date xmlns="http://schemas.microsoft.com/dynamics/gp/2006/01">
          <xsl:value-of select="invoice_date"/>
        </Date>
        
        <InvoiceDate xmlns="http://schemas.microsoft.com/dynamics/gp/2006/01">
          <xsl:value-of select="invoice_date"/>
        </InvoiceDate>

        <DocumentTypeKey   xmlns="http://schemas.microsoft.com/dynamics/gp/2006/01">
          <CompanyKey>
            <Id  xmlns="http://schemas.microsoft.com/dynamics/gp/2006/01">
              <xsl:value-of select="company_key_id"/>
            </Id>          
          </CompanyKey>
          <Type>Invoice</Type>
          <Id>
            <xsl:choose>
              <xsl:when test="customer_key_id='C100'">
                <xsl:text>NBWE</xsl:text>
              </xsl:when>
              <xsl:when test="customer_key_id='C101'">
                <xsl:text>WARRIOR</xsl:text>
              </xsl:when>
              <xsl:when test="customer_key_id='C102'">
                <xsl:text>PF</xsl:text>
              </xsl:when>
              <xsl:when test="customer_key_id='C103'">
                <xsl:text>JNBO</xsl:text>
              </xsl:when>
			  <xsl:when test="customer_key_id='C104'">
                <xsl:text>DRYDO</xsl:text>
              </xsl:when>      
            </xsl:choose>            
          </Id>
        </DocumentTypeKey>

        <CustomerKey xmlns="http://schemas.microsoft.com/dynamics/gp/2006/01">
          <CompanyKey>
            <Id xmlns="http://schemas.microsoft.com/dynamics/gp/2006/01">
              <xsl:value-of select="company_key_id"/>
            </Id>
          </CompanyKey>
          <Id>
            <xsl:value-of select="customer_key_id"/>
          </Id>
        </CustomerKey>



        <xsl:if test="has_payments = 'true'">
          <xsl:if test="has_payment_type_key = 'true'">
            <Payments xmlns="http://schemas.microsoft.com/dynamics/gp/2006/01">
              <xsl:if test="invoice_payment > 0">
                <xsl:if test="payment_type_key">
                  <SalesPayment>
                    <Date>
                      <xsl:value-of select="invoice_date"/>
                    </Date>
                    <PaymentAmount>
                      <Currency>USD</Currency>
                      <Value>
                        <xsl:value-of select="invoice_payment"/>
                      </Value>
                      <DecimalDigits>2</DecimalDigits>
                    </PaymentAmount>
                    <PaymentCardTypeKey>
                      <CompanyKey>
                        <Id xmlns="http://schemas.microsoft.com/dynamics/2006/01">
                          <xsl:value-of select="company_key_id"/>
                        </Id>
                      </CompanyKey>
                      <Id>
                        <xsl:value-of select="payment_type_key"/>
                      </Id>
                    </PaymentCardTypeKey>
                    <Type>Payment Card Payment</Type>
                  </SalesPayment>
                </xsl:if>
              </xsl:if>

              <xsl:if test="second_payment_amount > 0">
                <xsl:if test="second_payment_type">
                  <SalesPayment>
                    <Date>
                      <xsl:value-of select="invoice_date"/>
                    </Date>
                    <PaymentAmount>
                      <Currency>USD</Currency>
                      <Value>
                        <xsl:value-of select="second_payment_amount"/>
                      </Value>
                      <DecimalDigits>2</DecimalDigits>
                    </PaymentAmount>
                    <PaymentCardTypeKey>
                      <CompanyKey>
                        <Id xmlns="http://schemas.microsoft.com/dynamics/2006/01">
                          <xsl:value-of select="company_key_id"/>
                        </Id>
                      </CompanyKey>
                      <Id>
                        <xsl:value-of select="second_payment_type"/>
                      </Id>
                    </PaymentCardTypeKey>
                    <Type>Payment Card Payment</Type>
                  </SalesPayment>
                </xsl:if>
              </xsl:if>
            </Payments>
          </xsl:if>
        </xsl:if>        
        

        <Lines xmlns="http://schemas.microsoft.com/dynamics/gp/2006/01" >
          
          <xsl:for-each select="$lines">
            <xsl:if test="docnumber=$docnumber">
              <SalesInvoiceLine xmlns="http://schemas.microsoft.com/dynamics/gp/2006/01">
                
                <UnitPrice>
                  <Currency>USD</Currency>
                  <Value>
                    <xsl:value-of select="line_unit_price"/>
                  </Value>
                  <DecimalDigits>2</DecimalDigits>

                </UnitPrice>
                
                <xsl:if test="drop_ship">
                  <xsl:if test="drop_ship = 'true'">
                    <IsDropShip>true</IsDropShip>
                  </xsl:if>
                </xsl:if>
            
                <Quantity>
                  <Value>
                    <xsl:value-of select="line_qty"/>
                  </Value>
                  <DecimalDigits>0</DecimalDigits>
                </Quantity>

                <IsNonInventory>false</IsNonInventory>

                <UofM>
                  <xsl:text>Each</xsl:text>
                </UofM>
               

                <ItemKey>
                  <CompanyKey>
                    <Id xmlns="http://schemas.microsoft.com/dynamics/gp/2006/01">
                      <xsl:value-of select="company_key_id"/>
                    </Id>
                  </CompanyKey>
                  <Id>
                    <xsl:value-of select ="line_sku"/>
                  </Id>
                </ItemKey>                

                <Discount>
                  <Amount>
                    <Currency>USD</Currency>
                    <Value>                      
                      <xsl:value-of select="line_discountamount"/>
                    </Value>
                    <DecimalDigits>2</DecimalDigits>
                  </Amount>
                </Discount>

                <xsl:if test="account_cost_of_sales">
                  <CostOfSalesGLAccountKey>
                    <CompanyKey>
                      <Id xmlns="http://schemas.microsoft.com/dynamics/2006/01">
                        <xsl:value-of select="company_key_id"/>
                      </Id>
                    </CompanyKey>
                    <Id>
                      <xsl:value-of select="account_cost_of_sales"/>
                    </Id>
                    <IsEncrypted>false</IsEncrypted>
                  </CostOfSalesGLAccountKey>
                </xsl:if>

                <xsl:if test="account_in_use">
                  <InUseGLAccountKey>
                    <CompanyKey>
                      <Id xmlns="http://schemas.microsoft.com/dynamics/2006/01">
                        <xsl:value-of select="company_key_id"/>
                      </Id>
                    </CompanyKey>
                    <Id>
                      <xsl:value-of select="account_in_use"/>
                    </Id>
                    <IsEncrypted>false</IsEncrypted>
                  </InUseGLAccountKey>
                </xsl:if>

                <xsl:if test="account_inventory">
                  <InventoryGLAccountKey>
                    <CompanyKey>
                      <Id xmlns="http://schemas.microsoft.com/dynamics/2006/01">
                        <xsl:value-of select="company_key_id"/>
                      </Id>
                    </CompanyKey>
                    <Id>
                      <xsl:value-of select="account_inventory"/>
                    </Id>
                    <IsEncrypted>false</IsEncrypted>
                  </InventoryGLAccountKey>
                </xsl:if>

                <xsl:if test="account_discount">
                  <DiscountGLAccountKey>
                    <CompanyKey>
                      <Id xmlns="http://schemas.microsoft.com/dynamics/2006/01">
                        <xsl:value-of select="company_key_id"/>
                      </Id>
                    </CompanyKey>
                    <Id>
                      <xsl:value-of select="account_discount"/>
                    </Id>
                    <IsEncrypted>false</IsEncrypted>
                  </DiscountGLAccountKey>
                </xsl:if>

                <xsl:if test="account_returns">
                  <ReturnsGLAccountKey>
                    <CompanyKey>
                      <Id xmlns="http://schemas.microsoft.com/dynamics/2006/01">
                        <xsl:value-of select="company_key_id"/>
                      </Id>
                    </CompanyKey>
                    <Id>
                      <xsl:value-of select="account_returns"/>
                    </Id>
                    <IsEncrypted>false</IsEncrypted>
                  </ReturnsGLAccountKey>
                </xsl:if>

                <xsl:if test="account_sales">
                  <SalesGLAccountKey>
                    <CompanyKey>
                      <Id xmlns="http://schemas.microsoft.com/dynamics/2006/01">
                        <xsl:value-of select="company_key_id"/>
                      </Id>
                    </CompanyKey>
                    <Id>
                      <xsl:value-of select="account_sales"/>
                    </Id>
                    <IsEncrypted>false</IsEncrypted>
                  </SalesGLAccountKey>
                </xsl:if>


              </SalesInvoiceLine>

            </xsl:if>
          </xsl:for-each>
          
        </Lines>
        
      </SalesInvoice>
    </xsl:for-each>
  </xsl:template>  
</xsl:stylesheet>
