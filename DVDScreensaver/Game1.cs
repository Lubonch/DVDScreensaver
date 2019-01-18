using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DVDSreensaver
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D logo;
        Vector2 logoPosition = Vector2.Zero;
        Vector2 logoSpeed = new Vector2(150,150);
        Color logoColor = Color.White;
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        
        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = 720;
            graphics.PreferredBackBufferHeight = 480;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            
            spriteBatch = new SpriteBatch(GraphicsDevice);

            logo = Content.Load<Texture2D>("DVDlogo");
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

       
        protected override void Update(GameTime gameTime)
        {
            KeyboardState ks = Keyboard.GetState();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || ks.IsKeyDown(Keys.Escape))
                Exit();

            logoPosition += logoSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            int MaxX = GraphicsDevice.Viewport.Width - logo.Width;
            int MaxY = GraphicsDevice.Viewport.Height - logo.Height;

            if (ks.IsKeyDown(Keys.F))
            {
                graphics.PreferredBackBufferWidth = 1024;
                graphics.PreferredBackBufferHeight = 786;
                graphics.ToggleFullScreen();
            }

            if (logoPosition.X > MaxX || logoPosition.X < 0)
            { 
                logoSpeed.X *= -1;
                logoColor = Color.FromNonPremultiplied(ColorRNG.RDM(), ColorRNG.RDM(), ColorRNG.RDM(), ColorRNG.RDM());
            }
            if (logoPosition.Y > MaxY || logoPosition.Y < 0)
            {
                logoSpeed.Y *= -1;
                logoColor = Color.FromNonPremultiplied(ColorRNG.RDM(), ColorRNG.RDM(), ColorRNG.RDM(), ColorRNG.RDM());
            }

            base.Update(gameTime);
        }

        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
            spriteBatch.Draw(logo, logoPosition, logoColor);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
