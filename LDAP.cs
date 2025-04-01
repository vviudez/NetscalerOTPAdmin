using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Windows;
using System.Net;
using System.DirectoryServices.Protocols;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Security.Policy;

namespace NetscalerOTPAdmin
{
    public class LDAP
    {   
        public string ldapProtocol { get; set; }
        public string ldapServer { get; set; }
		public string ldapUser { get; set; }
		public string ldapPass { get; set; }
		public string ldapDomain { get; set; }
        public string ldapBaseDN { get; set; }

        public string userAttribute { get; set; }

        //private DirectoryEntry rootEntry;
        //private PrincipalContext context;
        LdapConnection connection;

		string[] attrs;

        public LDAP(){

        }

		public void ldapConnect()
		{
			if (!(String.IsNullOrEmpty(ldapPass)))
			{
				ldapPass = SimmetricAES.DecryptString(ldapPass);
				
				try
				{
                    attrs = new string[] { "objectsid", "givenname", "samaccountname", "userprincipalname", "cn", "displayname", "distinguishedname", "objectclass", "name", "mail", "phone", userAttribute, "primarygroupid", "lastlogon", "lastlogoff", "pwdlastset", "whencreated", "countrycode", "accountexpires" };

                    switch (ldapProtocol)
					{
						case "Unencrypted":
							connection = new LdapConnection(new LdapDirectoryIdentifier(ldapServer, 389, false, false));
							//required for searching on root of ldap directory https://github.com/dotnet/runtime/issues/64900
							connection.SessionOptions.ReferralChasing = ReferralChasingOptions.None;
							// must be version 3 for TLS.TLS is not supported in version 2.
							connection.SessionOptions.ProtocolVersion = 3;
							//use SSL
							connection.SessionOptions.SecureSocketLayer = false;
							connection.AuthType = AuthType.Basic;

							//connection.SessionOptions.Sealing = true;
							//connection.SessionOptions.Signing = true;
							connection.Credential = new NetworkCredential(ldapUser + "@" + ldapDomain, ldapPass);

							connection.Bind();
							break;

						case "SSL":
							connection = new LdapConnection(new LdapDirectoryIdentifier(ldapServer, 636, false, false));
							//required for searching on root of ldap directory https://github.com/dotnet/runtime/issues/64900
							connection.SessionOptions.ReferralChasing = ReferralChasingOptions.None;
							// must be version 3 for TLS.TLS is not supported in version 2.
							connection.SessionOptions.ProtocolVersion = 3;
							//use SSL
							connection.SessionOptions.SecureSocketLayer = true;
							connection.AuthType = AuthType.Basic;

							//connection.SessionOptions.Sealing = true;
							//connection.SessionOptions.Signing = true;
							connection.Credential = new NetworkCredential(ldapUser + "@" + ldapDomain, ldapPass);

							connection.Bind();
							break;

						case "TLS":

							connection = new LdapConnection(new LdapDirectoryIdentifier(ldapServer, 389, false, false));
							//required for searching on root of ldap directory https://github.com/dotnet/runtime/issues/64900
							connection.SessionOptions.ReferralChasing = ReferralChasingOptions.None;
							// must be version 3 for TLS.TLS is not supported in version 2.
							connection.SessionOptions.ProtocolVersion = 3;
							//use TLS
							connection.SessionOptions.StartTransportLayerSecurity(null);
							connection.AuthType = AuthType.Basic;

							//connection.SessionOptions.Sealing = true;
							//connection.SessionOptions.Signing = true;
							connection.Credential = new NetworkCredential(ldapUser + "@" + ldapDomain, ldapPass);

							connection.Bind();
							break;
					}
                }
                catch (LdapException lex)
                {
                    MessageBox.Show("LDAP Error: " + lex.Message);
                }
                catch (Exception ex)
				{
                    // Excepcion de conexión a LDAP
                    MessageBox.Show("Error on LDAP connection: " + ex.Message);
                }
			}

		}

		public SearchResultEntryCollection SearchOTPUsers()
		{
			//DirectorySearcher searcher;
			//searcher = new DirectorySearcher(connection);

			// Search for the user list having the userAttribute (defined in config) with some value
			//searcher.Filter = "(&(objectClass=user)(objectCategory=person)(" + userAttribute + "=*))";


			string searchFilter = String.Format("(&(objectClass=user)(objectCategory=person)({0}=*))", userAttribute);

            SearchRequest searchRequest = new SearchRequest
                (ldapBaseDN,
                 searchFilter,
                 System.DirectoryServices.Protocols.SearchScope.Subtree, attrs);

            var response = (SearchResponse)connection.SendRequest(searchRequest, TimeSpan.MaxValue);

            return response.Entries;
		}


		public SearchResultEntryCollection listUsers()
		{
            //DirectorySearcher searcher;
            //searcher = new DirectorySearcher(rootEntry);

            // Search for the user list having the userAttribute (defined in config) with some value
            //searcher.Filter = "(&(objectClass=user)(objectCategory=person)(!userAccountControl:1.2.840.113556.1.4.803:=2)(!" + userAttribute + "=*))";
            //return searcher.FindAll();


            string searchFilter = String.Format("(&(objectClass=user)(objectCategory=person)(!userAccountControl:1.2.840.113556.1.4.803:=2)(!{0}=*))", userAttribute);

            SearchRequest searchRequest = new SearchRequest
                (ldapBaseDN,
                 searchFilter,
                 System.DirectoryServices.Protocols.SearchScope.Subtree, attrs);

            var response = (SearchResponse)connection.SendRequest(searchRequest, TimeSpan.MaxValue);

            return response.Entries;
        }

		public SearchResultEntryCollection searchAllUsers(string match)
		{
			// DirectorySearcher searcher;
			//searcher = new DirectorySearcher(rootEntry);

			// Search for the user list having the userAttribute (defined in config) with some value
			//var queryFormat = "(&(objectClass=user)(objectCategory=person)(!userAccountControl:1.2.840.113556.1.4.803:=2)(!" + userAttribute + "=*)(|(SAMAccountName=*{0}*)(cn=*{0}*)(gn=*{0}*)(sn=*{0}*)(email=*{0}*)))";
			//string query = string.Format(queryFormat, match);

			//searcher.Filter = query;

			//return searcher.FindAll();

            string searchFilter = String.Format("(&(objectClass=user)(objectCategory=person)(!userAccountControl:1.2.840.113556.1.4.803:=2)(!{0}=*)(|(SAMAccountName=*{0}*)(cn=*{0}*)(gn=*{0}*)(sn=*{0}*)(email=*{0}*)))", match);

            SearchRequest searchRequest = new SearchRequest
				(ldapBaseDN,
				 searchFilter,
				System.DirectoryServices.Protocols.SearchScope.Subtree, attrs);

            var response = (SearchResponse)connection.SendRequest(searchRequest, TimeSpan.MaxValue);

            return response.Entries;
        }


        public SearchResultEntryCollection searchNoOTPUsers(string match)
        {
            // DirectorySearcher searcher;
            //searcher = new DirectorySearcher(rootEntry);

            // Search for the user list having the userAttribute (defined in config) with some value
            //var queryFormat = "(&(objectClass=user)(objectCategory=person)(!userAccountControl:1.2.840.113556.1.4.803:=2)(!" + userAttribute + "=*)(|(SAMAccountName=*{0}*)(cn=*{0}*)(gn=*{0}*)(sn=*{0}*)(email=*{0}*)))";
            //string query = string.Format(queryFormat, match);

            //searcher.Filter = query;

            //return searcher.FindAll();

            string searchFilter = String.Format("(&(objectClass=user)(objectCategory=person)(!userAccountControl:1.2.840.113556.1.4.803:=2)(!{0}=*)(!{1}=*)(|(SAMAccountName=*{0}*)(cn=*{0}*)(gn=*{0}*)(sn=*{0}*)(email=*{0}*)))", match, userAttribute);

            SearchRequest searchRequest = new SearchRequest
                (ldapBaseDN,
                 searchFilter,
                System.DirectoryServices.Protocols.SearchScope.Subtree, attrs);

            var response = (SearchResponse)connection.SendRequest(searchRequest, TimeSpan.MaxValue);

            return response.Entries;
        }


        public SearchResultEntry searchUser(string username)
		{

            //string dn = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, this.textBoxUsername.Text).DistinguishedName;
            //DirectorySearcher searcher;
			//searcher = new DirectorySearcher(rootEntry);

			// Search for the user list having the userAttribute (defined in config) with some value
			//var queryFormat = "(&(objectClass=user)(objectCategory=person)(!userAccountControl:1.2.840.113556.1.4.803:=2)(|(SAMAccountName=*{0}*)(cn=*{0}*)(gn=*{0}*)(sn=*{0}*)(email=*{0}*)))";
			//string query = string.Format(queryFormat, username);

			//searcher.Filter = query;

			//SearchResult fullSearch = searcher.FindOne();

			//return fullSearch.GetDirectoryEntry();

            string searchFilter = String.Format("(&(objectClass=user)(objectCategory=person)(!userAccountControl:1.2.840.113556.1.4.803:=2)(|(SAMAccountName=*{0}*)(cn=*{0}*)(gn=*{0}*)(sn=*{0}*)(email=*{0}*)))", username);

            SearchRequest searchRequest = new SearchRequest
				(ldapBaseDN,
				 searchFilter,
				System.DirectoryServices.Protocols.SearchScope.Subtree, attrs);

            var response = (SearchResponse)connection.SendRequest(searchRequest, TimeSpan.MaxValue);

            SearchResultEntry userFound = null;

            foreach (SearchResultEntry user in response.Entries)
			{
				if (user.Attributes["samaccountname"][0].ToString() == username)
				{
                    //MessageBox.Show("USER FOUND: " + username + " -- " + user.Attributes["samaccountname"][0].ToString()); 
					userFound = user;
					break;
				}
            }

            return userFound;

        }


        public bool updateUser(string username, string values)
		{
            SearchResultEntry objUser = this.searchUser(username);

			return this.updateUser(objUser, values);
        }

		public bool updateUser(SearchResultEntry userDirectoryEntry,string values)
		{
			bool estado = false;

			try
			{
                DirectoryAttributeModification attrupdate;

                if (string.IsNullOrEmpty(values) || (values == "#@"))
                {
                    // Create the modification request
                    attrupdate = new DirectoryAttributeModification
                    {
                        Name = userAttribute,
                        Operation = DirectoryAttributeOperation.Delete
                    };
                    attrupdate.Clear();

                }
                else
                {
                    // Create the modification request
                    attrupdate = new DirectoryAttributeModification
                    {
                        Name = userAttribute,
                        Operation = DirectoryAttributeOperation.Replace
                    };

                    /*DirectoryAttribute da = userDirectoryEntry.Attributes[userAttribute];
                    if (da != null ) { 
                        string atr = da[0].ToString();
                        if (String.IsNullOrEmpty(atr))
                        {
                            values = "#@" + values;
                        }
                    }
                    else
                    {
                        values = "#@" + values;
                    }*/
                    attrupdate.Add(values);
                }

                ModifyRequest request = new ModifyRequest(userDirectoryEntry.DistinguishedName, attrupdate);

                // Send the request
                connection.SendRequest(request);


				//DirectoryAttribute da = userDirectoryEntry.Attributes[userAttribute];
				//MessageBox.Show(da[0].ToString());

				/*{
                    string atr = da[0].ToString();
                    atr = atr + "," + values;
                    //userDirectoryEntry.Attributes[userAttribute].Add(values);
                    da.Clear();
                    da.Add(atr);
                }*/
				//userDirectoryEntry.CommitChanges();
				estado = true;
            }
            catch (DirectoryException dex)
            {
                MessageBox.Show(dex.Message);
                estado = false;
            }
            catch (Exception ex) {
				MessageBox.Show(ex.Message);
				estado = false;
                throw;
            }

            return estado;
        }

		public string GetAttribute(string username,string attribute)
		{
            string res = ""; 
			try
			{
				SearchResultEntry objUser = this.searchUser(username);

				if (objUser.Attributes[attribute] != null)
				{
					res = objUser.Attributes[attribute][0].ToString();
				}
			}            
			catch (Exception ex)
			{
				MessageBox.Show("Error accessing '"+attribute+"' attribute\r\n"+ex.Message.ToString());
                throw;
			}
            return res;

        }

		public string GetEmail(string username)
		{
			string res = "";
            try
            {
                SearchResultEntry objUser = this.searchUser(username);

				if (objUser.Attributes["mail"] != null) { 
					res=objUser.Attributes["mail"][0].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error accessing 'mail' attribute.\r\n" + ex.Message.ToString());
                throw;
            }
			return res;
        }
	}
}
