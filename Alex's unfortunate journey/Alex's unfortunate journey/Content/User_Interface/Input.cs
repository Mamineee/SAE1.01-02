using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Alex_s_unfortunate_journey.User_Interface
{


    public class Input
    {
        public KeyboardState _keyboardState;
        public int _sensPlayer;
        public int _vitessePlayer;
        public Input()
        {
            // may want to disable windows key temporarily in here (or not)
        }


        //------------
        // U P D A T E
        //------------
        public void Update(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            _keyboardState = Keyboard.GetState();
            // si fleche droite
            if (_keyboardState.IsKeyDown(Keys.Right) && !(_keyboardState.IsKeyDown(Keys.Left)))
                _sensPlayer = 1;
            _positionPlayer.X += _sensPlayer * _vitessePlayer * deltaTime;
        }

    }
}





/*game1 update 
inp.Update (gameTime);
if (inp._keyboardState.IsKeyDown(Keys.Escape)) Exit();     // <-- CHANGE LATER - (to go to menu state - then provide exit option in menu) 

game1 initialize
inp = new Input();

private Input inp;

using Alex_s_unfortunate_journey.User_Interface;*/