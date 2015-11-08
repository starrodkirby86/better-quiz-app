/*
 * DataBase Interface for the Core
 * This file contains all of the functions that interface with the DataBase
 */

using UnityEngine;	// For MonoBehaviour

public partial class Core : MonoBehaviour{
	/**
	 * Instructs the database to parse the XML file given by filename and add it to the collection
	 */
	public void addBinderFromXML(string filename){
		myDataBase.addBinderFromXML (filename);
	}

	/**
	 * Returns an array containing all loaded binders
	 */
	public Binder[] getAllBinders(){
		return myDataBase.viewBinders();
	}
}