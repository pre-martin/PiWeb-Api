﻿#region copyright
/* * * * * * * * * * * * * * * * * * * * * * * * * */
/* Carl Zeiss IMT (IZfM Dresden)                   */
/* Softwaresystem PiWeb                            */
/* (c) Carl Zeiss 2015                             */
/* * * * * * * * * * * * * * * * * * * * * * * * * */
#endregion

namespace DataService
{
	#region using

	using System;
	using Newtonsoft.Json;

	#endregion

	/// <summary>
	/// This element is used by search operations which return entities such as Parts,
	/// Characteristics, Measurements etc. It specifies, if the entities, which match the search
	/// criteria, should be returned with all their attributes, or if only the attributes
	/// specified in this element should be returned.
	/// </summary>
	public class AttributeSelector
	{
		#region constructor

		/// <summary>
		/// Constructor.
		/// </summary>
		public AttributeSelector()
		{
			AllAttributes = AllAttributeSelection.True;
		}

		/// <summary>
		/// Constructor. Initializes a new attribute selector for a specific <see cref="AllAttributeSelection"/>.
		/// </summary>
		public AttributeSelector( AllAttributeSelection allAttributes )
		{
			AllAttributes = allAttributes;
		}

		/// <summary>
		/// Constructor. Initializes a new attribute selector for a specific set of attributes <code>attributes</code>.
		/// </summary>
		public AttributeSelector( ushort[] attributes )
		{
			AllAttributes = AllAttributeSelection.False;
			Attributes = attributes;
		}

		#endregion

		#region properties

		/// <summary>
		/// Gets or sets the list of attributes that should be fetched.
		/// </summary>
		public ushort[] Attributes { get; set; }

		/// <summary>
		/// Gets or sets a value that determines whether to fetch all, no or just the query efficient attributes.
		/// </summary>
		public AllAttributeSelection AllAttributes { get; set; }

		#endregion
	}
}