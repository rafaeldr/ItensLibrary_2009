/*
 * Created by SharpDevelop.
 * User: Fiach
 * Date: 03/10/2004
 * Time: 17:20
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Windows.Forms;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Soap;
using System.IO;
using System.Collections;

namespace ItensLibrary
{
	/// <summary>
	/// Description of viewState.
	/// </summary>
	[Serializable()]public class formData
	{
		public ArrayList ar = new ArrayList();        
        
	}
    
	[Serializable()]public class formControl 
	{
		public Type controlType;        
		public int controlIndex;
		public PropertyInfo  [] pi;
		public object [] piValues;
		public FieldInfo [] fi;
		public object [] fiValues;
	}
    
    
	public class viewState
	{
		public viewState()
		{            
		}
		public static void saveViewState(Form anyForm)
		{

			string appPath;
			appPath = Application.StartupPath;
            
			formData instanceOfFromData = new formData();            
			int controlIndex =0;
			foreach (Control ctrl in anyForm.Controls)
			{
				formControl controlData = new formControl();
				Type t = ctrl.GetType();                
				controlData.fi = t.GetFields (BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
				controlData.pi = t.GetProperties (BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);                                            
				controlData.piValues = new object[controlData.pi.Length];
				controlData.controlType = t;
				controlData.controlIndex = controlIndex++;
				for(int i=0;i<controlData.pi.Length;i++)
				{
                    
					try
					{
						object val = controlData.pi[i].GetValue(ctrl,null);
						if (isReserializable(val))
						{
							controlData.piValues[i]=val;
						}
					}
					catch{}                    
				}
				controlData.fiValues = new object[controlData.fi.Length];
				for(int i=0;i<controlData.fi.Length;i++)
				{
					try
					{
						object val = controlData.fi[i].GetValue(ctrl);
						if (isReserializable(val)) controlData.fiValues[i]=val;
					}
					catch{}
				}        
				instanceOfFromData.ar.Add(controlData);
			}

			SoapFormatter sf = new SoapFormatter();
			FileStream fs = File.Create(appPath+ anyForm.Name + ".xml");            
			sf.Serialize(fs,instanceOfFromData);
			fs.Close();
		}
		public static void loadViewState(System.Windows.Forms.Form anyForm)
		{
			string appPath;
			appPath = Application.StartupPath;

			FileStream fs = File.OpenRead(appPath+anyForm.Name + ".xml");
			SoapFormatter sf = new SoapFormatter();
			formData instanceOfFromData = (formData)sf.Deserialize(fs);
            
			foreach (formControl ctrl in instanceOfFromData.ar)
			{
				Control c = anyForm.Controls[ctrl.controlIndex];
                
				for(int i=0;i<ctrl.pi.Length;i++)
				{                    
					try
					{
						if (ctrl.piValues[i]!=null)
						{
                            
							ctrl.controlType.InvokeMember(ctrl.pi[i].Name,
								BindingFlags.SetProperty,
								null, c, 
								new object [] {ctrl.piValues[i]});
						}
                        
					}
					catch{}                    
				}
                
				for(int i=0;i<ctrl.fi.Length;i++)
				{                    
					try
					{    
						if (ctrl.fiValues[i]!=null)
						{
                            
							ctrl.controlType.InvokeMember(ctrl.fi[i].Name,
								BindingFlags.SetField,
								null, c, 
								new object [] {ctrl.fiValues[i]});
						}
					}
					catch{}                    
				}    
			}
            
            
		}
		private static bool isReserializable(Object obj)
		{
			Type t=obj.GetType();
			if (!t.IsSerializable) return false;
			MemoryStream s = new MemoryStream();
			SoapFormatter sf = new SoapFormatter();
            
			try
			{
				sf.Serialize(s,obj);
				s.Position=0;
				Object copy = (Object)sf.Deserialize(s);
                
				return true;
			}
			catch(Exception e)
			{                
				return false;
			}
		}
	}
}
