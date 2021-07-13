<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
    <xsl:output indent="yes" method="html"/>
  <xsl:template match="/">
    <html>
      <body>
        <h2>Error!</h2>
        <table class="table">
          <tr>
            <th>Message</th>
            <th>ExceptionMessage</th>
          </tr>
          <xsl:for-each select="Error">
            <tr>
              <td>
                <xsl:value-of select="Message"/>
              </td>
              <td>
                <xsl:value-of select="ExceptionMessage"/>
              </td>
            </tr>
            <tr>
              <th style="text-align:left">ExceptionType</th>
              <th style="text-align:left">StackTrace</th>
            </tr>
            <tr>
              <td>
                <xsl:value-of select="ExceptionType"/>
              </td>
              <td>
                <xsl:value-of select="StackTrace"/>
              </td>
            </tr>
          </xsl:for-each>
        </table>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>