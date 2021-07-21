<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns="http://www.w3.org/1999/xhtml">
  <xsl:output method="html" indent="yes" omit-xml-declaration="yes" doctype-public="-//W3C//DTD XHTML 1.1//EN" doctype-system="http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd"/>
    
  <xsl:template match="UserEmail">
    <html>
      <head> <title>Użytkownik <xsl:value-of select="./UserName"/></title> </head>
      <body>
        <h3>Email aktywacyjny użytkownika <xsl:value-of select="UserName"/> na adres <xsl:value-of select="Email"/></h3>
        <xsl:apply-templates select="List"/>
      </body>
    </html>
  </xsl:template>

  <xsl:template match="List">
    <h3>Lista rzeczy</h3>
    <ul>
      <xsl:apply-templates/>
    </ul>
  </xsl:template>

  <xsl:template match="UserThing">
    <li><xsl:value-of select="Name"/></li>
  </xsl:template>
</xsl:stylesheet>