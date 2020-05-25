using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment2Sem2
{
    public partial class Form1 : Form
    {
        enum Stage { gateSelect, inputs }
        Stage stage = Stage.gateSelect;
        List<ILogicComponent> gatesAdded = new List<ILogicComponent>();
        ILogicComponent currentGate;
        string gate = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /// summary      All logic regarding which Gate and with what inputs will be created
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbOp.Text == null || cbOp.Text == "")
                    throw new InvalidInputException();
            }
            catch (InvalidInputException)
            {
                MessageBox.Show("Please input data");
                goto skipAll;
            }

            switch (stage)
            {
                case Stage.gateSelect:
                    gate = cbOp.Text;
                    break;

                case Stage.inputs:
                    if (gate == "NOT Gate")
                    {
                        string rawInput = cbOp.Text.ToLower();
                        rawInput = rawInput.Trim();
                        try
                        {
                            if (rawInput == "true")
                            {
                                currentGate = new NotGate(true);
                                gatesAdded.Add(currentGate);
                            }
                            else if (rawInput == "false")
                            {
                                currentGate = new NotGate(false);
                                gatesAdded.Add(currentGate);
                            }
                            else
                            {
                                throw new InvalidInputException();
                            }
                        }
                        catch (InvalidInputException)
                        {
                            MessageBox.Show("Please enter an appropriate input !");
                            break;
                        }
                    }
                    else
                    {

                        string rawInput = cbOp.Text.ToLower();
                        rawInput = rawInput.Trim();
                        string[] inputArray = rawInput.Split(' ');
                        List<bool> listPassed = new List<bool>();
                        try
                        {
                            if (inputArray.Length <= 1)
                            {
                                throw new InvalidInputException();
                            }
                            if (gate == "Half Adder" && inputArray.Length != 2)
                            {
                                throw new InvalidInputException();
                            }
                            else if (gate == "Full Adder" && inputArray.Length != 3)
                            {
                                throw new InvalidInputException();
                            }
                        }
                        catch (InvalidInputException)
                        {
                            MessageBox.Show("Please enter an appropriate input !");
                            break;
                        }
                        for (int i = 0; i < inputArray.Length; i++)
                        {
                            try
                            {
                                if (inputArray[i] == "true")
                                {
                                    listPassed.Add(true);
                                }
                                else if (inputArray[i] == "false")
                                {
                                    listPassed.Add(false);
                                }
                                else
                                {
                                    throw new InvalidInputException();
                                }
                            }
                            catch (InvalidInputException)
                            {
                                MessageBox.Show("Please enter an appropriate input !");
                                goto skipAll;
                            }
                        }

                        switch (gate)
                        {
                            case "AND Gate":
                                currentGate = new AndGate(listPassed);
                                gatesAdded.Add(currentGate);
                                break;

                            case "OR Gate":
                                currentGate = new OrGate(listPassed);
                                gatesAdded.Add(currentGate);
                                break;

                            case "XOR Gate":
                                currentGate = new XorGate(listPassed);
                                gatesAdded.Add(currentGate);
                                break;

                            case "Half Adder":
                                currentGate = new HalfAdder(listPassed);
                                gatesAdded.Add(currentGate);
                                break;

                            case "Full Adder":
                                currentGate = new FullAdder(listPassed);
                                gatesAdded.Add(currentGate);
                                break;
                        }
                    }
                    break;
            }
            if (stage == Stage.inputs)
                stage = Stage.gateSelect;
            else
                stage++;
            skipAll:
            FormReload();
        }
        /// summary      Used as an whole-program UI update method
        private void FormReload()
        {
            switch (stage)
            {
                case Stage.gateSelect:
                    lbDesc.Text = "Please select a GATE to add:";
                    cbOp.DropDownStyle = ComboBoxStyle.DropDownList;
                    cbOp.Text = "";
                    gate = "";
                    currentGate = null;
                    break;

                case Stage.inputs:
                    if (gate == "NOT Gate")
                        lbDesc.Text = "Please enter only one input (ex. true): ";
                    else if (gate == "Half Adder")
                        lbDesc.Text = "Please enter 2 inputs only (ex. true true)";
                    else if (gate == "Full Adder")
                        lbDesc.Text = "Please enter 3 inputs only (ex. true true false)";
                    else
                        lbDesc.Text = "Please enter INPUTS (ex. true true true false):";
                    cbOp.DropDownStyle = ComboBoxStyle.DropDown;
                    cbOp.Text = "";
                    break;
            }
            if (gatesAdded.Count == 0)
                lbNumberOfGates.Text = "";
            else
                lbNumberOfGates.Text = "Number of Gates : " + gatesAdded.Count.ToString();
            lbGates.Items.Clear();
            foreach (ILogicComponent i in gatesAdded)
            {
                if (gatesAdded.Count == 0)
                    break;
                else
                {
                    if (i.GetTypeAsString() == "Half Adder")
                    {
                        
                        string fixLast = i.GetInputsAsString().EndsWith(", ") ?
                            i.GetInputsAsString().Substring(0, i.GetInputsAsString().Length - 2) :
                            i.GetInputsAsString();

                        lbGates.Items.Add
                            (i.GetTypeAsString() + "  |  Sum: "
                            + i.GetOutput().ToString() + "  |  Carry: "
                            + (i as HalfAdder).GetCarryBit().ToString() + 
                            "  |  Input: " + fixLast);
                    }
                    else if (i.GetTypeAsString() == "Full Adder")
                    {

                        string fixLast = i.GetInputsAsString().EndsWith(", ") ?
                            i.GetInputsAsString().Substring(0, i.GetInputsAsString().Length - 2) :
                            i.GetInputsAsString();

                        lbGates.Items.Add
                            (i.GetTypeAsString() + "  |  Sum: "
                            + i.GetOutput().ToString() + "  |  Carry: "
                            + (i as FullAdder).GetCarryBit().ToString() +
                            "  |  Input: " + fixLast);
                    }
                    else
                    {
                        string fixLast = i.GetInputsAsString().EndsWith(", ") ?
                            i.GetInputsAsString().Substring(0, i.GetInputsAsString().Length - 2) :
                            i.GetInputsAsString();

                        lbGates.Items.Add(i.GetTypeAsString() + "  |  Output: "
                            + i.GetOutput().ToString() + "  |  Input: " + fixLast);
                    }
                }
            }
        }

        /// summary      Button Click Event for removal of created gates
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lbGates.SelectedIndex != -1)
            {
                gatesAdded.RemoveAt(lbGates.SelectedIndex);
                FormReload();
            }
        }
    }
}
