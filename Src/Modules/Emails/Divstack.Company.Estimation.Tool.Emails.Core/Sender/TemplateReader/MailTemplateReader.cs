﻿namespace Divstack.Company.Estimation.Tool.Emails.Core.Sender.TemplateReader;

internal sealed class MailTemplateReader : IMailTemplateReader
{
    public string Read(string relativePathToTemplate)
    {
        string[] paths =
        {
            $"{AppDomain.CurrentDomain.BaseDirectory}", relativePathToTemplate
        };
        var pathToTemplate = Path.Combine(paths);
        var html = File.ReadAllText(pathToTemplate);

        return html;
    }
}
