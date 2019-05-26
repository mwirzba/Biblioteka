<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:fo="http://www.w3.org/1999/XSL/Format">
<xsl:output method="html"/>

	<xsl:template match="/">
    <xsl:text disable-output-escaping='yes'>&lt;!DOCTYPE html></xsl:text>
	<xsl:element name="Library">
		<xsl:apply-templates select="/Library/Books"/>				
	</xsl:element>
	</xsl:template>


    <xsl:template match="/Library/Books">
    <xsl:text disable-output-escaping='yes'>&lt;!DOCTYPE html></xsl:text>
    <html>
     <body>
       <table border="1">
        <tr>
            <th>Title</th>
            <th>Author</th>
        </tr>
	     <xsl:for-each select="Book">
	        <xsl:sort select="Title"/>
		    <xsl:choose>
			    	<xsl:when test="@State='New'">
				    <tr>
					    <td>
						    <span style="color:green"><xsl:value-of select="Title"/></span>
						</td>
                        <td>
                          <!--  <xsl:value-of select="/Library/Authors/Author[@Id = /Library/Books/Book/@Id_Author]"/> -->
                             <xsl:choose>
                                    <xsl:when test="@Id_Author='A1'">
                                        <xsl:value-of select="/Library/Authors/Author[@Id = 'A1']"/>
                                    </xsl:when>
                                     <xsl:when test="@Id_Author='A2'">
                                        <xsl:value-of select="/Library/Authors/Author[@Id = 'A2']"/>
                                    </xsl:when>
                                     <xsl:when test="@Id_Author='A3'">
                                        <xsl:value-of select="/Library/Authors/Author[@Id = 'A3']"/>
                                    </xsl:when>
                                     <xsl:when test="@Id_Author='A4'">
                                        <xsl:value-of select="/Library/Authors/Author[@Id = 'A4']"/>
                                    </xsl:when>
                            </xsl:choose>
                        </td>
					</tr>
					</xsl:when>
					<xsl:when test="@State='Used'">
					    <tr>
						    <td>
							    <span style="color:purple"><xsl:value-of select="Title"/></span>
						    </td>
                             <td>
                                  <xsl:choose>
                                    <xsl:when test="@Id_Author='A1'">
                                        <xsl:value-of select="/Library/Authors/Author[@Id = 'A1']"/>
                                    </xsl:when>
                                     <xsl:when test="@Id_Author='A2'">
                                        <xsl:value-of select="/Library/Authors/Author[@Id = 'A2']"/>
                                    </xsl:when>
                                     <xsl:when test="@Id_Author='A3'">
                                        <xsl:value-of select="/Library/Authors/Author[@Id = 'A3']"/>
                                    </xsl:when>
                                     <xsl:when test="@Id_Author='A4'">
                                        <xsl:value-of select="/Library/Authors/Author[@Id = 'A4']"/>
                                    </xsl:when>
                                </xsl:choose>
                            </td>
					    </tr>
					</xsl:when>
                    <xsl:otherwise>
                        <tr>
						    <td>
							    <span style="color:red"><xsl:value-of select="Title"/></span>
						    </td>
                             <td>
                               <xsl:choose>
                                    <xsl:when test="@Id_Author='A1'">
                                        <xsl:value-of select="/Library/Authors/Author[@Id = 'A1']"/>
                                    </xsl:when>
                                     <xsl:when test="@Id_Author='A2'">
                                        <xsl:value-of select="/Library/Authors/Author[@Id = 'A2']"/>
                                    </xsl:when>
                                     <xsl:when test="@Id_Author='A3'">
                                        <xsl:value-of select="/Library/Authors/Author[@Id = 'A3']"/>
                                    </xsl:when>
                                     <xsl:when test="@Id_Author='A4'">
                                        <xsl:value-of select="/Library/Authors/Author[@Id = 'A4']"/>
                                    </xsl:when>
                                </xsl:choose>
                            </td>
					    </tr>
                    </xsl:otherwise>
		</xsl:choose>
	 </xsl:for-each>
	 </table>

 </body>
 </html>
</xsl:template>

</xsl:stylesheet>
