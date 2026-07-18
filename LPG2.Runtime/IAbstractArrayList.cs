using System.Collections;

namespace LPG2.Runtime
{

    public interface IAbstractArrayList<T > where T:  IAst
    {
    int size();
    T getElementAt(int i);
    ArrayList getList();
    bool add(T elt);
    ArrayList getAllChildren();
    }
}
