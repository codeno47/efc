<?xml version="1.0" encoding="UTF-8"?>

<xsl:stylesheet version="2.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

    <xsl:output version="4.0" method="html" indent="yes" encoding="UTF-8" doctype-public="-//W3C//DTD HTML 4.0 Transitional//EN" doctype-system="http://www.w3.org/TR/html4/loose.dtd"/>

    <xsl:template match="StyleCopViolations">

        <html>
            <head>
                <title/>
            </head>
            <body>
                    <h3 style="color:navy; font-family:verdana; ">
                        <span>
                            <xsl:text>Customized Style Cop Report</xsl:text>
                        </span>
                    </h3>            
                    <h4 style="color:black; font-family:verdana; ">
                        <span>
                            <xsl:text>Made from StyleCop XML output processed by a custom XSLt</xsl:text>
                        </span>
                    </h4>            


                    <table style="font-family:verdana; font-size:8px; width:100%; " border="1" cellpadding="3" width="100%">
                        <tbody>
                            <tr>
                                <td style="width:80px; ">
                                    <span>
                                        <xsl:text>Section</xsl:text>
                                    </span>
                                </td>
                                <td style="width:250px; ">
                                    <span>
                                        <xsl:text>Source</xsl:text>
                                        <xsl:text>LineNumber</xsl:text>                                        
                                    </span>
                                </td>
                                <td>
                                    <span>
                                        <xsl:text>RuleNamespace</xsl:text>
                                    </span>
                                </td>
                                <td>
                                    <span>
                                        <xsl:text>Rule</xsl:text>
                                    </span>
                                </td>
                                <td>
                                    <span>
                                        <xsl:text>Message</xsl:text>
                                    </span>
                                </td>                                
                                
                            </tr>
                            
                             <xsl:apply-templates select="Violation"/>                            

                        </tbody>
                    </table>
  
        </body>
          </html>            
    </xsl:template>

  

    <xsl:template match="Violation">
    
                            <tr>
                                <td style="width:80px; ">
                                    <span>
                                       <xsl:value-of select="@Section"/>
                                    </span>
                                </td>
                                <td style="width:250px; ">
                                    <span>
                                       <xsl:value-of select="@Source"/>
                                       <xsl:text>:</xsl:text>
                                       <xsl:value-of select="@LineNumber"/>
                                    </span>
                                </td>
                                <td>
                                    <span>
                                       <xsl:value-of select="@RuleNamespace"/>
                                       </span>
                                </td>

                                <td>
                                    <span>
                                       <xsl:value-of select="@RuleId"/>
                                       <xsl:text>:</xsl:text>
                                       <xsl:value-of select="@Rule"/>
                                       
                                       </span>
                                </td>     
                                <td>
                                    <span>

                             <xsl:apply-templates/>                            

                                       
                                    </span>
                                </td>                                
                                
                                
                            </tr>
    
    

    
    </xsl:template>
    
</xsl:stylesheet>