using UI;
using Zenject;

namespace Sources.Systems
{
    public class ViewSystems:Feature
    {
        public ViewSystems(Contexts contexts) : base("View systems")
        {
            Add(new CreateEntitySystem(contexts));
            Add(new AddViewSystem(contexts));
            Add(new RenderImageSystem(contexts));
            Add(new CreateCurrentSystem(contexts));
            Add(new ChangeCurrentSystem(contexts));
        }
    }
}