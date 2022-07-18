﻿#region copyright

/* * * * * * * * * * * * * * * * * * * * * * * * * */
/* Carl Zeiss Industrielle Messtechnik GmbH        */
/* Softwaresystem PiWeb                            */
/* (c) Carl Zeiss 2022                             */
/* * * * * * * * * * * * * * * * * * * * * * * * * */

#endregion

namespace Zeiss.PiWeb.Api.Rest.Dtos.Tests.Compatibility
{
	#region usings

	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Linq;
	using NUnit.Framework;
	using Zeiss.PiWeb.Api.Rest.Dtos.Data;

	using static PiWeb.Api.Definitions.WellKnownKeys;

	#endregion

	[TestFixture]
	public class CompatibilityTests
	{
		#region members

		private static readonly object[] TestCases =
		{
			new AttributeDefinitionDto { Key = 13, Description = "Test", Length = 43, QueryEfficient = false, Type = AttributeTypeDto.AlphaNumeric },

			new CatalogAttributeDefinitionDto { Key = 13, Description = "Test", QueryEfficient = false, Catalog = new Guid( "11D4115C-41A7-4D47-A353-AF5DF61503EA" ) },

			new AttributeDto( Characteristic.MeasurementModule, "Abweichungen" ),
			new AttributeDto( Characteristic.X, 2919.041 ),
			new AttributeDto( Characteristic.AlignmentType, 0 ),
			new AttributeDto( Measurement.Time, new DateTime( 2010, 11, 04, 19, 44, 52, 8, DateTimeKind.Utc ) ),
			new AttributeDto( Measurement.Time, (object)null ),

			new CatalogDto
			{
				Name = "TestCatalog",
				Uuid = new Guid( "8B23C6BB-EE2A-4BB3-A627-512C911F6FE8" ),
				ValidAttributes = new[] { Catalog.OperatorNumber, Catalog.OperatorName },
				CatalogEntries = new[]
				{
					new CatalogEntryDto
					{
						Key = 1,
						Attributes = new[]
						{
							new AttributeDto( Catalog.OperatorNumber, 13 ),
							new AttributeDto( Catalog.OperatorName, "Müller" ),
						}
					},
					new CatalogEntryDto
					{
						Key = 2,
						Attributes = new[]
						{
							new AttributeDto( Catalog.OperatorNumber, 42 ),
							new AttributeDto( Catalog.OperatorName, "Meier" ),
						}
					},
					new CatalogEntryDto
					{
						Key = 3,
						Attributes = new[]
						{
							new AttributeDto( Catalog.OperatorNumber, 73 ),
							new AttributeDto( Catalog.OperatorName, "Schulze" ),
						}
					}
				}
			},

			new ConfigurationDto
			{
				PartAttributes = new[]
				{
					new AttributeDefinitionDto { Key = Part.Number, Description = "Teilenummer", Length = 30, Type = AttributeTypeDto.AlphaNumeric },
					new AttributeDefinitionDto { Key = Part.VariantOfLine, Description = "Modell/Variante", Length = 40, Type = AttributeTypeDto.AlphaNumeric }
				},

				CharacteristicAttributes = new AbstractAttributeDefinitionDto[]
				{
					new AttributeDefinitionDto { Key = Characteristic.Number, Description = "Merkmalsnummer", Length = 20, Type = AttributeTypeDto.AlphaNumeric },
					new AttributeDefinitionDto { Key = Characteristic.ControlItem, Description = "Dokumentationspflicht", Type = AttributeTypeDto.Integer },
					new CatalogAttributeDefinitionDto { Key = 2004, Description = "Richtung", Catalog = new Guid( "d7291afb-0a67-4c1e-8bcc-6fc455bcc0e5" ) },
				},

				MeasurementAttributes = new[]
				{
					new AttributeDefinitionDto { Key = Measurement.Time, Description = "Zeit", Type = AttributeTypeDto.DateTime },
					new AttributeDefinitionDto { Key = 1, Description = "Messwert", Type = AttributeTypeDto.Float }
				},

				ValueAttributes = new AbstractAttributeDefinitionDto[]
				{
				},

				CatalogAttributes = new[]
				{
					new AttributeDefinitionDto { Key = 2009, Description = "Richtung", Length = 10, Type = AttributeTypeDto.AlphaNumeric }
				},

				VersioningType = VersioningTypeDto.Off
			},

			new DataMeasurementDto
			{
				Uuid = new Guid( "82DA1300-CC13-4920-A272-0AA33C4001A3" ),
				PartUuid = new Guid( "CF1938E5-C8D6-468D-9BC9-640A60A54105" ),
				LastModified = new DateTime( 2010, 11, 04, 19, 44, 52, 8, DateTimeKind.Utc ),
				Created = new DateTime( 2010, 12, 05, 22, 37, 49, 12, DateTimeKind.Utc ),
				Attributes = new[]
				{
					new AttributeDto( Measurement.Time, new DateTime( 2022, 01, 31, 19, 02, 59, 71, DateTimeKind.Utc) ),
					new AttributeDto( Measurement.BatchNumber, "5" ),
					new AttributeDto( Measurement.InspectorName, 2 ),
				},
				Characteristics = new[]
				{
					new DataCharacteristicDto { Uuid = new Guid("b71a5bd7-5406-46a3-a5b7-458ba1c0248d"), Value = new DataValueDto( 0.15108030390438515 ) },
					new DataCharacteristicDto { Uuid = new Guid("8c72afa6-fc67-4fbd-8606-e3727d79c8ff"), Value = new DataValueDto( -0.06273457511599848 ) },
					new DataCharacteristicDto { Uuid = new Guid("a5d13d7f-4029-4fb5-a7b5-3f40718df85a"), Value = new DataValueDto( 0.03185869918795966 ) }
				}
			},

			new InspectionPlanCharacteristicDto
			{
				Path = PathHelper.RoundtripString2PathInformation( "PC:/Blechteil/Abweichung_3/" ),
				Uuid = new Guid( "b71a5bd7-5406-46a3-a5b7-458ba1c0248d" ),
				Version = 0,
				Timestamp = new DateTime( 2022, 01, 31, 19, 02, 58, 683, DateTimeKind.Utc ),
				Attributes = new[]
				{
					new AttributeDto( Characteristic.NominalValue, 0.0 ),
					new AttributeDto( Characteristic.LowerSpecificationLimit, -0.5 ),
					new AttributeDto( Characteristic.UpperSpecificationLimit, 0.5 )
				}
			},

			new InspectionPlanPartDto
			{
				Path = PathHelper.RoundtripString2PathInformation( "P:/Blechteil/" ),
				CharChangeDate = new DateTime( 2022, 01, 31, 19, 2, 58, 767, DateTimeKind.Utc ),
				Uuid = new Guid( "fe85eefe-f08d-4e78-9f06-0e3b3cc9275e" ),
				Version = 0,
				Timestamp = new DateTime( 2022, 06, 30, 6, 25, 35, 46, DateTimeKind.Utc ),
				Attributes = new[]
				{
					new AttributeDto( Part.Number, 122345 ),
					new AttributeDto( Part.Abbreviation, "Blechteil" ),
					new AttributeDto( Part.Organisation, "Presswerk" )
				}
			},

			new OperationStatusDto { OperationUuid = new Guid( "7825FE38-1486-45CC-AA95-70658B83C7ED" ), ExecutionStatus = OperationExecutionStatusDto.Running, Exception = default },
			new OperationStatusDto { OperationUuid = new Guid( "7AE4BD0A-5EA4-4665-AB60-9D517E23BE6D" ), ExecutionStatus = OperationExecutionStatusDto.Exception, Exception = new Error("ErrorMessage") },

			new OrderDto { Entity = EntityDto.Characteristic, Attribute = Characteristic.LowerTolerance, Direction = OrderDirectionDto.Asc },
			new OrderDto { Entity = EntityDto.Measurement, Attribute = Measurement.MeasurementStatus, Direction = OrderDirectionDto.Desc },

			new ServiceInformationDto { EditionSpecified = true, ServerName = "TestServer", Version = "8.4.1.0", SecurityEnabled = true, Edition = "PiWebDB",
										FeatureList = new[] { "MeasurementAggregation", "JobEngineSupported" },
										PartCount = 1, CharacteristicCount = 13, MeasurementCount = 42, ValueCount = 73,
										InspectionPlanTimestamp = new DateTime( 2022, 06, 23, 10, 42, 0, 931, DateTimeKind.Utc ),
										MeasurementTimestamp = new DateTime( 2022, 03, 30, 15, 29, 43, 324, DateTimeKind.Utc ),
										ConfigurationTimestamp = new DateTime( 2022, 07, 13, 9, 35, 28, 858, DateTimeKind.Utc ),
										CatalogTimestamp = new DateTime( 2022, 03, 30, 15, 29, 42, 816, DateTimeKind.Utc ),
										StructureTimestamp = new DateTime( 2022, 03, 30, 15, 29, 41, 254, DateTimeKind.Utc ),
										RequestHeaderSize = 0 },

			new InterfaceVersionRange { SupportedVersions = new[] { new Version(7, 8, 2), new Version(8, 0), new Version(8, 2, 8) } },
		};

		private static readonly IReadOnlyDictionary<Type, Func<object, IStructuralEquatable>> EquatableFromType = new[]
		{
			EquatableFrom<AttributeDefinitionDto>( value => Tuple.Create( value.Key, value.Description, value.Length, value.QueryEfficient, value.Type ) ),

			EquatableFrom<CatalogAttributeDefinitionDto>( value => Tuple.Create( value.Key, value.Description, value.QueryEfficient, value.Catalog ) ),

			EquatableFrom<AbstractAttributeDefinitionDto>( value => EquatableFromType[ value is AttributeDefinitionDto ? typeof( AttributeDefinitionDto ) : typeof( CatalogAttributeDefinitionDto ) ]( value ) ),

			EquatableFrom<AttributeDto> (value => Tuple.Create( value.Key, value.Value ) ),

			EquatableFrom<CatalogDto>( value => Tuple.Create( value.Name, value.Uuid, value.ValidAttributes.ToArray(), EquatableFromMany( value.CatalogEntries ) ) ),

			EquatableFrom<CatalogEntryDto>( value => Tuple.Create( value.Key, EquatableFromMany( value.Attributes ) ) ),

			EquatableFrom<ConfigurationDto>( value => Tuple.Create( EquatableFromMany( value.PartAttributes ),
																   EquatableFromMany( value.CharacteristicAttributes ),
																   EquatableFromMany( value.MeasurementAttributes ),
																   EquatableFromMany( value.ValueAttributes ),
																   EquatableFromMany( value.CatalogAttributes ),
																   value.VersioningType ) ),

			EquatableFrom<DataCharacteristicDto>( value => Tuple.Create( value.Uuid, value.Value.MeasuredValue ) ),

			EquatableFrom<DataMeasurementDto>( value => Tuple.Create( value.Uuid, value.PartUuid, value.LastModified, value.Created, EquatableFromMany( value.Attributes ), EquatableFromMany( value.Characteristics ) ) ),

			EquatableFrom<InspectionPlanCharacteristicDto>( value => Tuple.Create( value.Path, value.Uuid, value.Version, value.Timestamp, EquatableFromMany( value.Attributes ) ) ),

			EquatableFrom<InspectionPlanPartDto>( value => Tuple.Create( value.Path, value.Uuid, value.Version, value.Timestamp, value.CharChangeDate, EquatableFromMany( value.Attributes ) ) ),

			EquatableFrom<OperationStatusDto>( value => Tuple.Create( value.OperationUuid, value.ExecutionStatus, value.Exception?.ExceptionMessage ?? string.Empty ) ),

			EquatableFrom<OrderDto>( value => Tuple.Create( value.Entity, value.Attribute, value.Direction ) ),

			EquatableFrom<ServiceInformationDto>( value => Tuple.Create( value.EditionSpecified, value.Edition, value.ServerName, value.SecurityEnabled, value.FeatureList.ToArray(), value.RequestHeaderSize,
															Tuple.Create( value.PartCount, value.CharacteristicCount, value.MeasurementCount, value.ValueCount ),
															Tuple.Create( value.InspectionPlanTimestamp, value.MeasurementTimestamp, value.ConfigurationTimestamp, value.CatalogTimestamp, value.StructureTimestamp )) ),

			EquatableFrom<InterfaceVersionRange>( value => value.SupportedVersions.ToArray() ),
		}
		.ToDictionary( pair => pair.Key, pair => pair.Value );

		private static readonly Newtonsoft.Json.JsonSerializerSettings Settings = new()
		{
			NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore,
			Converters = { new Newtonsoft.Json.Converters.VersionConverter() }
		};

		private static readonly System.Text.Json.JsonSerializerOptions Options = new()
		{
			DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
		};

		#endregion

		#region methods

		[TestCaseSource( nameof( TestCases ) )]
		public void Backward_Compatible<T>( T value )
		{
			var json = Newtonsoft.Json.JsonConvert.SerializeObject( value, Settings );
			
			var deserializedValue = System.Text.Json.JsonSerializer.Deserialize<T>( json, Options );

			var equatable = EquatableFromType[typeof( T )];

			var expected = equatable( value );
			var actual = equatable( deserializedValue );

			Assert.AreEqual( expected, actual, $"{typeof( T ).Name}" );
		}

		[TestCaseSource( nameof( TestCases ) )]
		public void Forward_Compatible<T>( T value )
		{
			var json = System.Text.Json.JsonSerializer.Serialize( value, Options );

			var deserializedValue = Newtonsoft.Json.JsonConvert.DeserializeObject<T>( json, Settings );

			var equatable = EquatableFromType[typeof( T )];

			var expected = equatable( value );
			var actual = equatable( deserializedValue );

			Assert.AreEqual( expected, actual, $"{typeof( T ).Name}" );
		}

		private static KeyValuePair<Type, Func<object, IStructuralEquatable>> EquatableFrom<T>( Func<T, IStructuralEquatable> func )
		{
			return new( typeof( T ), value => func( (T)value ) );
		}

		private static IStructuralEquatable EquatableFromMany<T>( IEnumerable<T> values )
		{
			return values.Select( value => EquatableFromType[typeof( T )]( value ) ).ToArray();
		}

		#endregion
	}
}