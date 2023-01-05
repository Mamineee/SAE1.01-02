using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
//using MonoGame.Extended.Animations;
using MonoGame.Extended.Serialization;
using MonoGame.Extended.Content;
using MonoGame.Extended.Sprites;
using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Renderers;
using MonoGame.Extended.TextureAtlases;

namespace Alex_s_unfortunate_journey
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        //map
        private TiledMap _tiledMap;
        private TiledMapRenderer _tiledMapRenderer;

        //perso
        private Vector2 _positionPerso;
        private AnimatedSprite _persoIdle;
        private AnimatedSprite _persoWalk;

        private int _vitesse;

        //input
        private KeyboardState _keyboardState;
        //collision
        //private bool IsCollision(ushort x, ushort y)
        //{
        //    // définition de tile qui peut être null (?)
        //    TiledMapTile? tile;
        //    if (_mapLayer.TryGetTile(x, y, out tile) == false)
        //        return false;
        //    if (!tile.Value.IsBlank)
        //        return true;
        //    return false;
        //}

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            //map
            GraphicsDevice.BlendState = BlendState.AlphaBlend;
            _graphics.PreferredBackBufferWidth = 1200;
            _graphics.PreferredBackBufferHeight = 768;
            _graphics.ApplyChanges();
            //perso
            _positionPerso = new Vector2(304,624);
            _vitesse = 100;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            //map
            _tiledMap = Content.Load<TiledMap>("niveauDepart2");
            _tiledMapRenderer = new TiledMapRenderer(GraphicsDevice, _tiledMap);
            //perso
            SpriteSheet spriteSheetIdle = Content.Load<SpriteSheet>("GraveRobber_Idle.sf", new JsonContentLoader());
            SpriteSheet spriteSheetWalk = Content.Load<SpriteSheet>("GraveRobber_Walk.sf", new JsonContentLoader());
            _persoIdle = new AnimatedSprite(spriteSheetIdle);
            _persoWalk = new AnimatedSprite(spriteSheetWalk);
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            _keyboardState = Keyboard.GetState();
            float walkSpeed = deltaTime * _vitesse;

            //map
            _tiledMapRenderer.Update(gameTime);
            //perso
            _persoIdle.Play("idle");
            _persoIdle.Update(deltaTime);
            if (_keyboardState.IsKeyDown(Keys.D))
            {
                ushort tx = (ushort)(_positionPerso.X / _tiledMap.TileWidth + 1);
                ushort ty = (ushort)(_positionPerso.Y / _tiledMap.TileHeight + 1);
                _persoWalk.Play("Walk_Right");
                _positionPerso.X += walkSpeed;
                //if (IsCollision(tx, ty))
                //    _positionPerso.X -= walkSpeed;
            }


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            //map
            _tiledMapRenderer.Draw();
            //perso
            _spriteBatch.Begin();
            //_spriteBatch.Draw(_persoIdle, _positionPerso,null ,Color.White,0, new Vector2(0,0), 3.0f, SpriteEffects.None, 0);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}