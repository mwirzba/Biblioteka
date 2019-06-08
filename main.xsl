<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:output indent="yes" method="html" encoding="UTF-8"/>
  
	<xsl:template match="/">
    <xsl:text disable-output-escaping='yes'>&lt;!DOCTYPE html></xsl:text>
    <html lang="fr">
    <head>
        <title>Library</title>
    </head>
     <body>
	  <h1> Books</h1>
       <h3>statistics</h3>
       <ul>
            <li>Total Number of Books:  <xsl:value-of select="count(Library/Books/Book)"/></li>
            <li>Total Salaries of Employees: <xsl:value-of select="sum(Library/Employees/Employee/Salary/text())"/></li>
            <li>Average of Salaries of Employees: <xsl:value-of select="round(sum(Library/Employees/Employee/Salary/text()) div count(/Library/Employees/Employee) * 100) div 100"/></li>
					<xsl:variable name="books" select="/Library/Books/Book/Title/text()" />
			<li>Number of books realeased after 1999 year: <xsl:value-of select="count(Library/Books/Book/ReleaseDate[starts-with(.,'2')])"/> </li>
       </ul>
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
						<xsl:variable name="idVar" select="@Id_Author" />
                            <xsl:value-of select="/Library/Authors/Author[@Id = $idVar]"/>
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
						<xsl:variable name="idVar" select="@Id_Author" />
                            <xsl:value-of select="/Library/Authors/Author[@Id = $idVar]"/>
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
						<xsl:variable name="idVar" select="@Id_Author" />
                            <xsl:value-of select="/Library/Authors/Author[@Id = $idVar]"/>
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
	 
	      <table border="1">
        <tr>
            <th>Name</th>
            <th>Surname</th>
            <th>Email</th>
        </tr>
     
	     <xsl:for-each select="Library/Employees/Employee">
	        <xsl:sort select="concat(Name,Surname)"/>
				    <tr>
					    <td>
						    <xsl:value-of select="Name"/>
						</td>
                        <td>
                            <xsl:value-of select="Surname"/>
                        </td>
                        <td>
							<a href="mailto:{Email}">
								<xsl:value-of select="Email"/>
							</a>
                        </td>
					</tr>
	 </xsl:for-each>
	 </table>


 </body>
 </html>		
    
</xsl:template>

</xsl:stylesheet>
