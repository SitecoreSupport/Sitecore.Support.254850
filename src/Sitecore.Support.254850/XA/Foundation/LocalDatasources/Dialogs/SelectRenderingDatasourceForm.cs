namespace Sitecore.Support.XA.Foundation.LocalDatasources.Dialogs
{
  using Sitecore;
  using Sitecore.Data;
  using Sitecore.Globalization;
  using System.Collections.Specialized;
  using System.Linq;
  using System.Web;

  public class SelectRenderingDatasourceForm : Sitecore.XA.Foundation.LocalDatasources.Dialogs.SelectRenderingDatasourceForm
  {
    protected new Language ContentLanguage
    {
      get
      {
        return ServerProperties["cont_language"] as Language;
      }
      set
      {
        ServerProperties["cont_language"] = value;
      }
    }
    
    protected new void CopyDataSource(string sourceRootId)
    {
      ID iD = ID.Parse(sourceRootId);
      if (ContextItem.Database.GetItem(iD) != null)
      {
        NameValueCollection nameValueCollection = new NameValueCollection();
        nameValueCollection["itemid"] = iD.ToString();
        nameValueCollection["language"] = ContextItem.Language.Name;
        nameValueCollection["test"] = "testvalue";
        Context.ClientPage.Start(this, "CopyDatasourceClientPipeline", nameValueCollection);
      }
    }

    protected new void CreateDataSource(string id)
    {
      if (ContextItem.Database.GetItem(id) != null)
      {
        NameValueCollection nameValueCollection = new NameValueCollection();
        nameValueCollection["itemid"] = id;
        nameValueCollection["language"] = ContextItem.Language.Name;
        nameValueCollection["test"] = "testvalue";
        Context.ClientPage.Start(this, "CreateDatasourceClientPipeline", nameValueCollection);
      }
    }
    
    protected new void CreateLocalDataSource(string id)
    {
      NameValueCollection nameValueCollection = new NameValueCollection();
      nameValueCollection["itemid"] = id;
      nameValueCollection["language"] = ContextItem.Language.Name;
      nameValueCollection["test"] = "testvalue";
      Context.ClientPage.Start(this, "CreateLocalDatasourceClientPipeline", nameValueCollection);
    }
    
  }
}