# Reference/demo app to showcase the cloudscribe Forms and Surveys Product

[More information here]((https://www.cloudscribe.com/products/cloudscribe-forms-and-surveys-solution))

If you are new to cloudscribe see [the introduction](https://www.cloudscribe.com/docs/introduction)

The sample solution uses NoDb by default which is a file system storage, this enabled us to pre-populate the sample with some sample forms. You can change it to use MS SQL, My Sql, PostgreSql or SQLite by appsettings.json.

You should create an appsettings.Development.json file to override any settings you want to change. This file is gitignored to avoid credentials going into source control.

#### You can login using the default credentials admin@admin.com with password admin

After you login the Administration menu will appear. You can create custom forms and surveys under Administration > Forms and Surveys.

There is also integration with cloudscribe Simple Content to make it easy to create pages with the forms and surveys you create in the administration area. You can click the plus icon on the top right side of the page to create new pages and you will see a content template there that allows you to add a form or survey to the page.

We created a couple of forms already and added them to the Contact page and the Conference Registration page.

Note that if you configure an email provider in appsettings then a new option will apear in the form edit page to let you enter a comma separated list of emails to get notification of form submissions.

Note there is a convention if you use the following question names: email, firstName, lastName, in forms/surveys then for authenticated users those fields can be pre-populated on the form.

### Have Questions?

[![Join the chat at https://gitter.im/joeaudette/cloudscribe](https://badges.gitter.im/joeaudette/cloudscribe.svg)](https://gitter.im/joeaudette/cloudscribe?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

### Screenshots

![Form List screen shot](/screen-shots/form-survey-list.jpg)

![Form Builder screen shot](/screen-shots/form-builder1.jpg)




