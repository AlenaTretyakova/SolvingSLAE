namespace Решение_СЛАУ_методом_итераций
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.equation = new System.Windows.Forms.TextBox();
            this.button_add = new System.Windows.Forms.Button();
            this.system = new System.Windows.Forms.ListBox();
            this.button_solve = new System.Windows.Forms.Button();
            this.accuracy = new System.Windows.Forms.TextBox();
            this.label_equation = new System.Windows.Forms.Label();
            this.label_accuracy = new System.Windows.Forms.Label();
            this.label_system = new System.Windows.Forms.Label();
            this.label_answer = new System.Windows.Forms.Label();
            this.button_remove = new System.Windows.Forms.Button();
            this.button_clear = new System.Windows.Forms.Button();
            this.label_solution = new System.Windows.Forms.Label();
            this.answer = new System.Windows.Forms.Label();
            this.panel_answer = new System.Windows.Forms.Panel();
            this.solution = new System.Windows.Forms.Label();
            this.panel_solution = new System.Windows.Forms.Panel();
            this.button_export = new System.Windows.Forms.Button();
            this.button_save = new System.Windows.Forms.Button();
            this.panel_answer.SuspendLayout();
            this.panel_solution.SuspendLayout();
            this.SuspendLayout();
            // 
            // equation
            // 
            this.equation.Location = new System.Drawing.Point(49, 47);
            this.equation.Name = "equation";
            this.equation.Size = new System.Drawing.Size(169, 22);
            this.equation.TabIndex = 0;
            // 
            // button_add
            // 
            this.button_add.Location = new System.Drawing.Point(49, 185);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(81, 23);
            this.button_add.TabIndex = 1;
            this.button_add.Text = "Add";
            this.button_add.UseVisualStyleBackColor = true;
            this.button_add.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // system
            // 
            this.system.FormattingEnabled = true;
            this.system.ItemHeight = 16;
            this.system.Location = new System.Drawing.Point(282, 47);
            this.system.Name = "system";
            this.system.Size = new System.Drawing.Size(339, 132);
            this.system.TabIndex = 2;
            // 
            // button_solve
            // 
            this.button_solve.Location = new System.Drawing.Point(137, 185);
            this.button_solve.Name = "button_solve";
            this.button_solve.Size = new System.Drawing.Size(81, 23);
            this.button_solve.TabIndex = 3;
            this.button_solve.Text = "Solve";
            this.button_solve.UseVisualStyleBackColor = true;
            this.button_solve.Click += new System.EventHandler(this.ButtonSolve_Click);
            // 
            // accuracy
            // 
            this.accuracy.Location = new System.Drawing.Point(49, 128);
            this.accuracy.Name = "accuracy";
            this.accuracy.Size = new System.Drawing.Size(169, 22);
            this.accuracy.TabIndex = 4;
            // 
            // label_equation
            // 
            this.label_equation.AutoSize = true;
            this.label_equation.Location = new System.Drawing.Point(46, 18);
            this.label_equation.Name = "label_equation";
            this.label_equation.Size = new System.Drawing.Size(114, 16);
            this.label_equation.TabIndex = 6;
            this.label_equation.Text = "Enter the equation";
            // 
            // label_accuracy
            // 
            this.label_accuracy.AutoSize = true;
            this.label_accuracy.Location = new System.Drawing.Point(49, 100);
            this.label_accuracy.Name = "label_accuracy";
            this.label_accuracy.Size = new System.Drawing.Size(131, 16);
            this.label_accuracy.TabIndex = 7;
            this.label_accuracy.Text = "Specify the accuracy";
            // 
            // label_system
            // 
            this.label_system.AutoSize = true;
            this.label_system.Location = new System.Drawing.Point(279, 18);
            this.label_system.Name = "label_system";
            this.label_system.Size = new System.Drawing.Size(128, 16);
            this.label_system.TabIndex = 8;
            this.label_system.Text = "System of equations";
            // 
            // label_answer
            // 
            this.label_answer.AutoSize = true;
            this.label_answer.Location = new System.Drawing.Point(49, 242);
            this.label_answer.Name = "label_answer";
            this.label_answer.Size = new System.Drawing.Size(51, 16);
            this.label_answer.TabIndex = 9;
            this.label_answer.Text = "Answer";
            // 
            // button_remove
            // 
            this.button_remove.Location = new System.Drawing.Point(281, 185);
            this.button_remove.Name = "button_remove";
            this.button_remove.Size = new System.Drawing.Size(81, 23);
            this.button_remove.TabIndex = 10;
            this.button_remove.Text = "Remove";
            this.button_remove.UseVisualStyleBackColor = true;
            this.button_remove.Click += new System.EventHandler(this.ButtonRemove_Click);
            // 
            // button_clear
            // 
            this.button_clear.Location = new System.Drawing.Point(368, 185);
            this.button_clear.Name = "button_clear";
            this.button_clear.Size = new System.Drawing.Size(81, 23);
            this.button_clear.TabIndex = 11;
            this.button_clear.Text = "Clear";
            this.button_clear.UseVisualStyleBackColor = true;
            this.button_clear.Click += new System.EventHandler(this.ButtonClear_Click);
            // 
            // label_solution
            // 
            this.label_solution.AutoSize = true;
            this.label_solution.Location = new System.Drawing.Point(279, 242);
            this.label_solution.Name = "label_solution";
            this.label_solution.Size = new System.Drawing.Size(55, 16);
            this.label_solution.TabIndex = 13;
            this.label_solution.Text = "Solution";
            // 
            // answer
            // 
            this.answer.AutoSize = true;
            this.answer.Location = new System.Drawing.Point(18, 12);
            this.answer.Name = "answer";
            this.answer.Size = new System.Drawing.Size(0, 16);
            this.answer.TabIndex = 5;
            // 
            // panel_answer
            // 
            this.panel_answer.BackColor = System.Drawing.Color.White;
            this.panel_answer.Controls.Add(this.answer);
            this.panel_answer.Location = new System.Drawing.Point(49, 277);
            this.panel_answer.Name = "panel_answer";
            this.panel_answer.Size = new System.Drawing.Size(169, 246);
            this.panel_answer.TabIndex = 12;
            // 
            // solution
            // 
            this.solution.AutoSize = true;
            this.solution.Location = new System.Drawing.Point(18, 12);
            this.solution.Name = "solution";
            this.solution.Size = new System.Drawing.Size(0, 16);
            this.solution.TabIndex = 5;
            // 
            // panel_solution
            // 
            this.panel_solution.AutoScroll = true;
            this.panel_solution.BackColor = System.Drawing.Color.White;
            this.panel_solution.Controls.Add(this.solution);
            this.panel_solution.Location = new System.Drawing.Point(282, 277);
            this.panel_solution.Name = "panel_solution";
            this.panel_solution.Size = new System.Drawing.Size(339, 246);
            this.panel_solution.TabIndex = 14;
            // 
            // button_export
            // 
            this.button_export.Location = new System.Drawing.Point(455, 185);
            this.button_export.Name = "button_export";
            this.button_export.Size = new System.Drawing.Size(80, 23);
            this.button_export.TabIndex = 15;
            this.button_export.Text = "Export";
            this.button_export.UseVisualStyleBackColor = true;
            this.button_export.Click += new System.EventHandler(this.ButtonExport_Click);
            // 
            // button_save
            // 
            this.button_save.Location = new System.Drawing.Point(541, 185);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(80, 23);
            this.button_save.TabIndex = 16;
            this.button_save.Text = "Save";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 567);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.button_export);
            this.Controls.Add(this.panel_solution);
            this.Controls.Add(this.label_solution);
            this.Controls.Add(this.button_clear);
            this.Controls.Add(this.button_remove);
            this.Controls.Add(this.label_answer);
            this.Controls.Add(this.label_system);
            this.Controls.Add(this.label_accuracy);
            this.Controls.Add(this.label_equation);
            this.Controls.Add(this.accuracy);
            this.Controls.Add(this.button_solve);
            this.Controls.Add(this.system);
            this.Controls.Add(this.button_add);
            this.Controls.Add(this.equation);
            this.Controls.Add(this.panel_answer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Solving a system of linear equations";
            this.panel_answer.ResumeLayout(false);
            this.panel_answer.PerformLayout();
            this.panel_solution.ResumeLayout(false);
            this.panel_solution.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox equation;
        private System.Windows.Forms.Button button_add;
        private System.Windows.Forms.ListBox system;
        private System.Windows.Forms.Button button_solve;
        private System.Windows.Forms.TextBox accuracy;
        private System.Windows.Forms.Label label_equation;
        private System.Windows.Forms.Label label_accuracy;
        private System.Windows.Forms.Label label_system;
        private System.Windows.Forms.Label label_answer;
        private System.Windows.Forms.Button button_remove;
        private System.Windows.Forms.Button button_clear;
        private System.Windows.Forms.Label label_solution;
        private System.Windows.Forms.Label answer;
        private System.Windows.Forms.Panel panel_answer;
        private System.Windows.Forms.Label solution;
        private System.Windows.Forms.Panel panel_solution;
        private System.Windows.Forms.Button button_export;
        private System.Windows.Forms.Button button_save;
    }
}

