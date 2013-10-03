<xsl:stylesheet version="1.0"  xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output omit-xml-declaration="yes" indent="yes"/>
<xsl:template match="rss">
    <rss>
      <xsl:apply-templates/>
    </rss>
  </xsl:template>
  <xsl:template match="channel">
    <channel>
      <xsl:apply-templates/>
  </channel>
</xsl:template>
<xsl:template match="item">
  <item>
    <xsl:attribute name="otsikko">
      <xsl:value-of select="title"/>
    </xsl:attribute>
    <xsl:attribute name="linkki">
      <xsl:value-of select="link"/>
    </xsl:attribute>
    </item>
</xsl:template>
</xsl:stylesheet>
