namespace Divstack.Company.Estimation.Tool.Valuations.ArchTests;

using Common;
using Common.Pattern;

public class ApplicationTests
{
    private const string I = "I";
    
    [Test]
    public void GIVEN_application_layer_WHEN_the_application_layer_is_validated_THEN_it_should_not_depend_on_infrastructure_projects()
    {
        var policy = Types.InAssembly(Project.Application!)!
            .Should()!
            .NotHaveDependencyOnAny(Project.InfrastructureParts!);

        var result = policy!.GetResult();

        result!.FailingTypeNames!.Should()!.BeNullOrEmpty();
        result.IsSuccessful.Should()!.BeTrue();
    }
    
    [Test]
    public void GIVEN_application_layer_WHEN_type_is_interface_THEN_should_have_name_started_with_I()
    {
        var policy = Types.InAssembly(Project.Application!)
            .That()
            .AreInterfaces()
            .Should()
            .HaveNameStartingWith(I);
        
        var result = policy!.GetResult();

        result!.FailingTypeNames!.Should()!.BeNullOrEmpty();
        result.IsSuccessful.Should()!.BeTrue();
    }
    
    [Test]
    public void GIVEN_application_layer_WHEN_type_is_internal_and_is_class_THEN_should_be_sealed()
    {
        var policy = Types.InAssembly(Project.Application!)
            .That()
            .AreClasses()
            .Should()
            .BeSealed();
        
        var result = policy!.GetResult();

        result!.FailingTypeNames!.Should()!.BeNullOrEmpty();
        result.IsSuccessful.Should()!.BeTrue();
    }
    
    [Theory]
    [TestCase("validation")]
    public void GIVEN_application_layer_THEN_all_validators_should_be_internal(string name)
    {
        var pattern = SearchPatterns.ContainsNamePattern(name);
        var policy = Types.InAssembly(Project.Application!)!
            .That()!
                .HaveNameMatching(pattern)
            .Should()
                .NotBePublic();

        var result = policy!.GetResult();

        result!.FailingTypeNames!.Should()!.BeNullOrEmpty();
        result.IsSuccessful.Should()!.BeTrue();
    }

    [Theory]
    [TestCase("Repository")]
    public void GIVEN_application_layer_WHEN_the_application_layer_is_validated_THEN_it_should_not_have_particular_types_of_classes(string name)
    {
        var pattern = SearchPatterns.ContainsNamePattern(name);
        var policy = Types.InAssembly(Project.Application!)!
            .Should()!
            .NotHaveNameMatching(pattern);

        var result = policy!.GetResult();

        result!.FailingTypeNames!.Should()!.BeNullOrEmpty();
        result.IsSuccessful.Should()!.BeTrue();
    }
}
