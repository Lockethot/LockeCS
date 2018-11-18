

using Lockethot.Collections.Generic;

namespace Lockethot.Design.Behavioral.CommandPattern
{
    public class CommandStack : ReversableStack<IPatternCommand>
    {
        #region Constructors
        public CommandStack() { }
        #endregion

        #region Public Virtual Methods
        public override void Do(IPatternCommand command)
        {
            base.Do(command);
            command.Do(); 
        }

        public override IPatternCommand Undo()
        {
            var toUndo = base.Undo();
            toUndo.Undo();
            return toUndo;
        }

        public override IPatternCommand Redo()
        {
                var toRedo = base.Redo();
                toRedo.Do();
                return toRedo;
        }
        #endregion
    }
}
