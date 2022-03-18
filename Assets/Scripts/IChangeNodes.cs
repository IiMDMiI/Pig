using System;

public interface IChangeNodes 
{
    event Action<Node> OnCurrentNodeChanged;
    
    
}
