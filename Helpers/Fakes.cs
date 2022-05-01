namespace Testing.Fakes;

public class FakeLidRepository : ILidRepository{
    public static List<Lid> _leden = new List<Lid>();
    
    public Task<List<Lid>> GetAllLeden(){
        return Task.FromResult(_leden);
    }

    public Task<Lid> GetLid(string id){
        var result = _leden.Find(l => l.LidId == id);
        return Task.FromResult(result);
    }

    public Task<List<Lid>> GetLedenByTakId(string takId){
        throw new NotImplementedException();
    }

    public Task<List<Lid>> GetLedenByGroepId(string groepId){
        throw new NotImplementedException();
    }

    public Task<Lid> AddLid(Lid newLid){
        _leden.Add(newLid);
        return Task.FromResult(newLid);
    }

    public Task<Lid> UpdateLid(string lidId, Lid lid){
        _leden.Add(lid);
        return Task.FromResult(lid);
    }

    public Task DeleteLid(string lidId){
        throw new NotImplementedException();
    }
}

public class FakeTakRepository : ITakRepository{
    public static List<Tak> _takken = new List<Tak>();

    public Task<List<Tak>> GetAllTakken(){
        return Task.FromResult(_takken);
    }

    public Task<Tak> GetTak(string takId){
        var result = _takken.Find(t => t.TakId == takId);
        return Task.FromResult(result);
    }

    public Task<Tak> AddTak(Tak newTak){
        _takken.Add(newTak);
        return Task.FromResult(newTak);
    }

    public Task<Tak> AddFakeTak(Tak newTak){
        _takken.Add(newTak);
        return Task.FromResult(newTak);
    }

    public Task<Tak> UpdateTak(string takId, Tak tak){
        _takken.Add(tak);
        return Task.FromResult(tak);
    }

    public Task DeleteTak(string takId){
        throw new NotImplementedException();
    }
}

public class FakeGroepRepository : IGroepRepository{
    public static List<Groep> _groepen = new List<Groep>();    
    public Task<List<Groep>> GetAllGroepen(){
        return Task.FromResult(_groepen);
    }

    public Task<Groep> GetGroep(string groepId){
        var result = _groepen.Find(g => g.GroepId == groepId);
        return Task.FromResult(result);
    }

    public Task<Groep> AddGroep(Groep newGroep){
        _groepen.Add(newGroep);
        return Task.FromResult(newGroep);
    }

    public Task<Groep> UpdateGroep(string groepId, Groep groep){
        _groepen.Add(groep);
        return Task.FromResult(groep);
    }

    public Task DeleteGroep(string groepId){
        throw new NotImplementedException();
    }
}