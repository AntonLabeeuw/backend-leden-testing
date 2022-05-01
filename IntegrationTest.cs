namespace Testing.Test;

public class IntegrationTests
{
    [Fact]
    public async Task Should_return_leden()
    {
        var application = Helper.CreateApi();
        var client = application.CreateClient();

        var result = await client.GetAsync("/leden");

        result.StatusCode.Should().Be(HttpStatusCode.OK);
        var leden = await result.Content.ReadFromJsonAsync<List<Lid>>();
        Assert.NotNull(leden);
        Assert.IsType<List<Lid>>(leden);
    }

    [Fact]
    public async Task Should_return_takken()
    {
        var application = Helper.CreateApi();
        var client = application.CreateClient();

        var result = await client.GetAsync("/takken");

        result.StatusCode.Should().Be(HttpStatusCode.OK);
        var takken = await result.Content.ReadFromJsonAsync<List<Tak>>();
        Assert.NotNull(takken);
        Assert.IsType<List<Tak>>(takken);
    }

    [Fact]
    public async Task Should_return_groepen()
    {
        var application = Helper.CreateApi();
        var client = application.CreateClient();

        var result = await client.GetAsync("/groepen");

        result.StatusCode.Should().Be(HttpStatusCode.OK);
        var groepen = await result.Content.ReadFromJsonAsync<List<Groep>>();
        Assert.NotNull(groepen);
        Assert.IsType<List<Groep>>(groepen);
    }

    [Fact]
    public async Task should_Return_Lid_By_Id(){
        var application = Helper.CreateApi();
        var client = application.CreateClient();

        var fakeLidRepository = new FakeLidRepository();
        await fakeLidRepository.AddLid(new Lid() { LidId = "1", Naam = "test", Voornaam = "1", Tak = new Tak() { TakNaam = "testje" }, Groep = new Groep() { GroepNaam = "test", Site = "test", Email = "test", Oprichtingsdatum = "test", Rekeningnummer = "test", Adres = "test", Postcode = "test", Gemeente = "test", Groepsleider1 = "test", Groepsleider2 = "test", Secretaris = "test", Penningmeester = "test" }, Adres1 = "test", Adres2 = "test", Email = "test", Telefoon = "test", Gsm = "test", Geboortedatum = "test", Geslacht = "test", Beperking = 0, VerminderdLidgeld = 0 });

        var result = await client.GetAsync("lid/1");

        result.StatusCode.Should().Be(HttpStatusCode.OK);
        var leden = await result.Content.ReadFromJsonAsync<Lid>();
        Assert.NotNull(leden);
        Assert.IsType<Lid>(leden);
        Assert.Equal("1", leden.LidId);
    }

    // [Fact]
    // public async Task Should_Return_Leden_By_TakId(){
    //     var application = Helper.CreateApi();
    //     var client = application.CreateClient();
    // }

    // [Fact]
    // public async Task Should_Return_Leden_By_GroepId(){
    //     var application = Helper.CreateApi();
    //     var client = application.CreateClient();
    // }

    [Fact]
    public async Task should_Return_Tak_By_Id(){
        var application = Helper.CreateApi();
        var client = application.CreateClient();

        var fakeTakRepository = new FakeTakRepository();
        await fakeTakRepository.AddTak(new Tak() { TakId = "1", TakNaam = "testje" });

        var result = await client.GetAsync("tak/1");

        result.StatusCode.Should().Be(HttpStatusCode.OK);
        var takken = await result.Content.ReadFromJsonAsync<Tak>();
        Assert.NotNull(takken);
        Assert.IsType<Tak>(takken);
        Assert.Equal("1", takken.TakId);
    }

    [Fact]
    public async Task should_Return_Groep_By_Id(){
        var application = Helper.CreateApi();
        var client = application.CreateClient();

        var fakeGroepRepository = new FakeGroepRepository();
        await fakeGroepRepository.AddGroep(new Groep() { GroepId = "1", GroepNaam = "test", Site = "test", Email = "test", Oprichtingsdatum = "test", Rekeningnummer = "test", Adres = "test", Postcode = "test", Gemeente = "test", Groepsleider1 = "test", Groepsleider2 = "test", Secretaris = "test", Penningmeester = "test" });

        var result = await client.GetAsync("groep/1");

        result.StatusCode.Should().Be(HttpStatusCode.OK);
        var groepen = await result.Content.ReadFromJsonAsync<Groep>();
        Assert.NotNull(groepen);
        Assert.IsType<Groep>(groepen);
        Assert.Equal("1", groepen.GroepId);
    }

    [Fact]
    public async Task Add_Lid_Created(){
        var application = Helper.CreateApi();
        var client = application.CreateClient();

        var newLid = new Lid (){
            Naam = "testing",
            Voornaam = "testing",
            Tak = new Tak () { TakNaam = "testing" },
            Groep = new Groep () { GroepNaam = "testing", Site = "testing", Email = "testing", Oprichtingsdatum = "testing", Rekeningnummer = "testing", Adres = "testing", Postcode = "testing", Gemeente = "testing", Groepsleider1 = "testing", Groepsleider2 = "testing", Secretaris = "testing", Penningmeester = "testing" },
            Adres1 = "testing", 
            Adres2 = "testing",
            Email = "testing",
            Telefoon = "testing", 
            Gsm = "testing",
            Geboortedatum = "testing",
            Geslacht = "testing",
            Beperking = 0,
            VerminderdLidgeld = 0
        };
        
        var result = await client.PostAsJsonAsync("/lid", newLid);
        Console.WriteLine(await result.Content.ReadAsStringAsync());
        // Assert.NotNull(result.Headers.Location);
        result.StatusCode.Should().Be(HttpStatusCode.Created);
    }

    [Fact]
    public async Task Add_Tak_Created(){
        var application = Helper.CreateApi();
        var client = application.CreateClient();

        var newTak = new Tak (){
            TakNaam = "testing"
        };

        var result = await client.PostAsJsonAsync("/tak", newTak);
        Assert.NotNull(result.Headers.Location);
        result.StatusCode.Should().Be(HttpStatusCode.Created);
    }

    [Fact]
    public async Task Add_Groep_Created(){
        var application = Helper.CreateApi();
        var client = application.CreateClient();

        var newGroep = new Groep (){
            GroepNaam = "testing",
            Site = "testing",
            Email = "testing",
            Oprichtingsdatum = "testing",
            Rekeningnummer = "testing",
            Adres = "testing",
            Postcode = "testing",
            Gemeente = "testing",
            Groepsleider1 = "testing",
            Groepsleider2 = "testing",
            Secretaris = "testing",
            Penningmeester = "testing"
        };

        var result = await client.PostAsJsonAsync("/groep", newGroep);
        // Assert.NotNull(result.Headers.Location);
        Console.WriteLine(await result.Content.ReadAsStringAsync());
        result.StatusCode.Should().Be(HttpStatusCode.Created);
    }

    [Fact]
    public async Task Update_Lid_Updated(){
        var application = Helper.CreateApi();
        var client = application.CreateClient();

        var fakeLidRepository = new FakeLidRepository();
        await fakeLidRepository.AddLid(new Lid() { LidId = "1", Naam = "test", Voornaam = "1", Tak = new Tak() { TakNaam = "testje" }, Groep = new Groep() { GroepNaam = "test", Site = "test", Email = "test", Oprichtingsdatum = "test", Rekeningnummer = "test", Adres = "test", Postcode = "test", Gemeente = "test", Groepsleider1 = "test", Groepsleider2 = "test", Secretaris = "test", Penningmeester = "test" }, Adres1 = "test", Adres2 = "test", Email = "test", Telefoon = "test", Gsm = "test", Geboortedatum = "test", Geslacht = "test", Beperking = 0, VerminderdLidgeld = 0 });

        var updatedLid = new Lid (){
            Naam = "testing",
            Voornaam = "testing",
            Tak = new Tak () { TakNaam = "testing" },
            Groep = new Groep () { GroepNaam = "testing", Site = "testing", Email = "testing", Oprichtingsdatum = "testing", Rekeningnummer = "testing", Adres = "testing", Postcode = "testing", Gemeente = "testing", Groepsleider1 = "testing", Groepsleider2 = "testing", Secretaris = "testing", Penningmeester = "testing" },
            Adres1 = "testing", 
            Adres2 = "testing",
            Email = "testing",
            Telefoon = "testing", 
            Gsm = "testing",
            Geboortedatum = "testing",
            Geslacht = "testing",
            Beperking = 0,
            VerminderdLidgeld = 0
        };

        var result = await client.PutAsJsonAsync("/lid/1", updatedLid);
        // Assert.NotNull(result.Headers.Location);
        Console.WriteLine(await result.Content.ReadAsStringAsync());
        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task Update_Tak_Updated(){
        var application = Helper.CreateApi();
        var client = application.CreateClient();

        var fakeTakRepository = new FakeTakRepository();
        await fakeTakRepository.AddTak(new Tak() { TakId = "1", TakNaam = "testing" });

        var updatedTak = new Tak (){
            TakNaam = "testing update"
        };

        var result = await client.PutAsJsonAsync("/tak/1", updatedTak);
        // Assert.NotNull(result.Headers.Location);
        Console.WriteLine(await result.Content.ReadAsStringAsync());
        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task Update_Groep_Updated(){
        var application = Helper.CreateApi();
        var client = application.CreateClient();

        var fakeGroepRepository = new FakeGroepRepository();
        await fakeGroepRepository.AddGroep(new Groep() { GroepId = "1", GroepNaam = "test", Site = "test", Email = "test", Oprichtingsdatum = "test", Rekeningnummer = "test", Adres = "test", Postcode = "test", Gemeente = "test", Groepsleider1 = "test", Groepsleider2 = "test", Secretaris = "test", Penningmeester = "test" });

        var updatedGroep = new Groep (){
            
        };

        var result = await client.PutAsJsonAsync("/groep/1", updatedGroep);
        // Assert.NotNull(result.Headers.Location);
        Console.WriteLine(await result.Content.ReadAsStringAsync());
        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    // [Fact]
    // public async Task Delete_Tak(){
    //     var application = Helper.CreateApi();
    //     var client = application.CreateClient();

    //     var fakeTakRepository = new FakeTakRepository();
    //     await fakeTakRepository.AddTak(new Tak() { TakId = "1", TakNaam = "testing" });

    //     var result = await client.DeleteAsync("/tak/1");
    //     result.StatusCode.Should().Be(HttpStatusCode.OK);
    // }
} 