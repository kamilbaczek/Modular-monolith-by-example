namespace Divstack.Company.Estimation.Tool.Emails.Core.Sender.TemplateReader;

public interface IMailTemplateReader
{
    string Read(string relativePathToTemplate);
}
