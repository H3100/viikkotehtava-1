<xsl:stylesheet version="1.0"  xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output omit-xml-declaration="yes" indent="yes"/>
  
<xsl:template match="CATALOG">  
	  <catalog>
		<xsl:apply-templates />
	  </catalog>
</xsl:template>
	
<xsl:template match="CD">
  <record>
    <xsl:attribute name="nimi">
      <xsl:value-of select="TITLE"/>
    </xsl:attribute>
    <xsl:attribute name="artisti">
      <xsl:value-of select="ARTIST"/>
    </xsl:attribute>
    <xsl:attribute name="maa">
      <xsl:value-of select="COUNTRY"/>
    </xsl:attribute>
	<xsl:attribute name="yritys">
      <xsl:value-of select="COMPANY"/>
    </xsl:attribute>
	<xsl:attribute name="hinta">
      <xsl:value-of select="PRICE"/>
    </xsl:attribute>
    <xsl:attribute name="vuosi">
      <xsl:value-of select="YEAR"/>
    </xsl:attribute>

  </record>
</xsl:template>

</xsl:stylesheet>