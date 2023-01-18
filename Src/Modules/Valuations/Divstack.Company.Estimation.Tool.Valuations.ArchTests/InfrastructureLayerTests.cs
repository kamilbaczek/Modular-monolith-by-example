namespace Divstack.Company.Estimation.Tool.Valuations.ArchTests;

using Common;
using Common.Pattern;

public class InfrastructureLayerTests
{
    private const string I = "I";
    
    [Test]
    public void GIVEN_infrastructure_THEN_it_should_not_depend_on_API()
    {
        var api = Project.Api.GetName().Name;
        var policy = Types.InAssembly(Project.Infrastructure!)!
            .Should()!
            .NotHaveDependencyOnAny(api);

        var result = policy!.GetResult();

        result!.FailingTypeNames!.Should()!.BeNullOrEmpty();
        result.IsSuccessful.Should()!.BeTrue();
    }
    
    [Test]
    public void GIVEN_infrastructure_WHEN_type_is_interface_THEN_should_have_name_started_with_I()
    {
        var policy = Types.InAssembly(Project.Infrastructure!)
            .That()
            .AreInterfaces()
            .Should()
            .HaveNameStartingWith(I);
        
        var result = policy!.GetResult();

        result!.FailingTypeNames!.Should()!.BeNullOrEmpty();
        result.IsSuccessful.Should()!.BeTrue();
    }
    
    [Test]
    public void GIVEN_infrastructure_WHEN_type_is_internal_AND_is_class_THEN_should_be_sealed()
    {
        var policy = Types.InAssembly(Project.Infrastructure!)
            .That()
            .AreClasses()
            .Should()
            .BeSealed();
        
        var result = policy!.GetResult();

        result!.FailingTypeNames!.Should()!.BeNullOrEmpty();
        result.IsSuccessful.Should()!.BeTrue();
    }
    
    [Test]
    public void GIVEN_infrastructure_WHEN_type_is_configuration_THEN_should_not_be_public()
    {
        var pattern = SearchPatterns.ContainsNamePattern("Configuration");
        var policy = Types.InAssembly(Project.Infrastructure!)
            .That()
            .AreClasses()
            .And()
            .HaveNameMatching(pattern)
            .Should()
            .NotBePublic();
        
        var result = policy!.GetResult();

        result!.FailingTypeNames!.Should()!.BeNullOrEmpty();
        result.IsSuccessful.Should()!.BeTrue();
    }

    [Theory]
    [TestCase("Command")]
    [TestCase("Endpoint")]
    public void GIVEN_infrastructure_THEN_it_should_not_have_particular_types_of_classes(string name)
    {
        var pattern = SearchPatterns.ContainsNamePattern(name);
        var policy = Types.InAssembly(Project.Infrastructure!)!
            .Should()!
            .NotHaveNameMatching(pattern);

        var result = policy!.GetResult();

        result!.FailingTypeNames!.Should()!.BeNullOrEmpty();
        result.IsSuccessful.Should()!.BeTrue();
    }
}
