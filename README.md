# Cofoundry.Samples.PageModules

A bare website showing various examples of how to implement page module types.

If you have any requests for example module types, [let us know](https://github.com/cofoundry-cms/cofoundry/wiki/Feedback-&-Community).

#### To get started:

1. Create a database named 'Cofoundry.Samples.PageModules' and check the Cofoundry connection string in the web.config file is correct for you sql server instance
2. Run the website and navigate to *"/admin"*, which will display the setup screen
3. Enter an application name and setup your user account. Submit the form to complete the site setup. 
4. Log in and add a page with the *General* template, click on save and edit to go to the visual editor and play around with the page modules.

####  Example Page Module Types:

- **DirectoryList:** Lists pages in a specific directory. Demonstrates searching for pages using `IPageRepository` and using the `WebDirectoryAttribute` data model attribute.
- **PageList:** An orderable list of links to pages. Demonstrates quering for caches page routes using `IPageRepository`, the `PageCollectionAttribute` data model attribute and generating links to pages from page objects.
- **PageSnippet:** Displays summary information about a page. Demonstrates the `PageAttribute` data model attribute, querying and manipulating module data and handling availability of linked entities (due to draft status).



