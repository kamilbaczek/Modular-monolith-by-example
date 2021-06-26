namespace Divstack.Company.Estimation.Tool.Modules.Emails.Core.Sender.TemplateReader
{
    public interface IMailTemplateReader
    {
        string Read(string relativePathToTemplate);
    }
}