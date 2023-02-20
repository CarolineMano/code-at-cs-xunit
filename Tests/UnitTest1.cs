using Program;
using Xunit;

namespace Tests;

public class ContactServiceTest
{
    [Theory]
    [InlineData("Adriana", "12345-6789", "adriana@email.com")]
    public void AddContact_ValidContact_ReturnsTrue(string name, string phone, string email)
    {
        var contactService = new ContactService();

        var result = contactService.AddContact(name, phone, email);

        Assert.True(result);
    }

    [Theory]
    [InlineData(null, "12345-6789", "adriana@email.com")]
    public void AddContact_InvalidContact_ReturnsTrue(string name, string phone, string email)
    {
        var contactService = new ContactService();

        var result = contactService.AddContact(name, phone, email);

        Assert.False(result);
    }

    [Fact]
    public void ListContacts_ListIsEmpty_ReturnsMessage()
    {
        var contactService = new ContactService();
        var expectedResult = "Não há contatos cadastrados.";

        var result = contactService.ListContacts();

        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void ListContacts_ListIsNotEmpty_ReturnsList()
    {
        var contactService = new ContactService();
        contactService.contacts.Add(new Contact("Adriana", "12345-6789", "adriana@email.com"));
        var expectedResult = "Lista de contatos:\n1. Adriana - 12345-6789 - adriana@email.com\n";

        var result = contactService.ListContacts();

        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void UpdateContact_InvalidIndex_ReturnsErrorMessage()
    {
        var contactService = new ContactService();
        var expectedResult = "Índice inválido. Tente novamente.";

        var result = contactService.UpdateContact(-1, "Adriana", "12345-6789", "adriana@email.com");

        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void UpdateContact_NewNamePassed_ReturnsMessageWithUpdatedName()
    {
        var contactService = new ContactService();
        contactService.contacts.Add(new Contact("Adriana", "12345-6789", "adriana@email.com"));
        var expectedResult = "Contato 'Suzana' atualizado com sucesso.";

        var result = contactService.UpdateContact(0, "Suzana", "12345-6789", "adriana@email.com");

        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void RemoveContact_InvalidIndex_ReturnsErrorMessage()
    {
        var contactService = new ContactService();
        var expectedResult = "Índice inválido. Tente novamente.";

        var result = contactService.RemoveContact(-1);

        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void RemoveContact_ValidIndex_ReturnsSuccessMessage()
    {
        var contactService = new ContactService();
        contactService.contacts.Add(new Contact("Adriana", "12345-6789", "adriana@email.com"));
        var expectedResult = "Contato 'Adriana' removido com sucesso.";

        var result = contactService.RemoveContact(0);

        Assert.Equal(expectedResult, result);
    }
}