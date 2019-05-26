<?xml version="1.0"?>

<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

  
	<xsl:template match="/">
    <xsl:text disable-output-escaping='yes'>&lt;!DOCTYPE html></xsl:text>
    <html>
    <head>
        <title>Library</title>
       <h1> Books</h1>
       <h3>statistics</h3>
       <ul>
            <li>Total Number of Books:  <xsl:value-of select="count(Library/Books/Book)"/></li>
            <li>Total Salaries of Employees: <xsl:value-of select="sum(Library/Employees/Employee/Salary/text())"/></li>
            <li>Average of Salaries of Employees: <xsl:value-of select="round(sum(Library/Employees/Employee/Salary/text()) div count(/Library/Employees/Employee) * 100) div 100"/></li>
            <li>Max Salary of Employees: <xsl:value-of select="count(Library/Books/Book)"/></li>
        </ul>
        
    </head>
     <body>
       <table border="1">
        <tr>
            <th>Title</th>
            <th>Author</th>
            <th>Description</th>
        </tr>
     
	     <xsl:for-each select="Library/Books/Book">
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
                        <td>
                            <xsl:if test="@Description">
                                 <xsl:value-of select="@Description"/>
                            </xsl:if>
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
                            <td>
                            <xsl:if test="@Description">
                                 <xsl:value-of select="@Description"/>
                            </xsl:if>
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
                            <td>
                            <xsl:if test="@Description">
                                 <xsl:value-of select="@Description"/>
                            </xsl:if>
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
