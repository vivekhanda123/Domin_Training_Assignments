using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_factory_pattern
{
    public interface IButton
    {
        void Render();
    }
    public interface ITextField
    {
        void Render();
    }
    public interface IUIFactory
    {
        IButton CreateButton();
        ITextField CreateTextField();
    }
    public class LightButton : IButton
    {
        public void Render()
        {
            Console.WriteLine("Rendering Light Theme button!...");
        }
    }
    public class LightTextField : ITextField
    {
        public void Render()
        {
            Console.WriteLine("Rendering Light theme text Field!...");
        }
    }
    public class DarkButton : IButton
    {
        public void Render()
        {
            Console.WriteLine("Rendering Dark Theme button!...");
        }
    }
    public class DarkTextField : ITextField
    {
        public void Render()
        {
            Console.WriteLine("Rendering Dark theme text Field!...");
        }
    }
    public class LightUIFactory : IUIFactory
    {
        public IButton CreateButton()
        {
            return new LightButton();
        }

        public ITextField CreateTextField()
        {
            throw new NotImplementedException();
        }
    }
    public class DarkUIFactory : IUIFactory
    {
        public IButton CreateButton()
        {
            return new DarkButton();
        }

        public ITextField CreateTextField()
        {
            throw new NotImplementedException();
        }
    }
    public class Client
    {
        private readonly IButton _button;
        private readonly ITextField _textField;
        public Client(IUIFactory factory)
        {
            _button = factory.CreateButton();
            _textField = factory.CreateTextField();
        }
        public void RenderUI()
        {
            _button.Render();
            _textField.Render();
        }
    }
}
