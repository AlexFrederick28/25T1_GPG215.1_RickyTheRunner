#include "pch-cpp.hpp"






struct String_t;
struct XmlAttributeAttribute_t157535EDD908EB83E442B1DEFF2A151B076962BE;
struct XmlElementAttribute_t1E2EE1E1AB1D03CA9BD7774A39E44D81C649BDD5;

IL2CPP_EXTERN_C RuntimeClass* XmlReader_t4C709DEF5F01606ECB60B638F1BD6F6E0A9116FD_il2cpp_TypeInfo_var;


IL2CPP_EXTERN_C_BEGIN
IL2CPP_EXTERN_C_END

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
struct U3CModuleU3E_t4791F64F4B6411D4D033A002CAD365D597AA2451 
{
};
struct Attribute_tFDA8EFEFB0711976D22474794576DAF28F7440AA  : public RuntimeObject
{
};
struct String_t  : public RuntimeObject
{
	int32_t ____stringLength;
	Il2CppChar ____firstChar;
};
struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F  : public RuntimeObject
{
};
struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F_marshaled_pinvoke
{
};
struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F_marshaled_com
{
};
struct XmlNode_t3180B9B3D5C36CD58F5327D9F13458E3B3F030AF  : public RuntimeObject
{
};
struct XmlReader_t4C709DEF5F01606ECB60B638F1BD6F6E0A9116FD  : public RuntimeObject
{
};
struct UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B 
{
	uint32_t ___m_value;
};
struct Void_t4861ACF8F4594C3437BB48B6E56783494B843915 
{
	union
	{
		struct
		{
		};
		uint8_t Void_t4861ACF8F4594C3437BB48B6E56783494B843915__padding[1];
	};
};
struct XmlAttributeAttribute_t157535EDD908EB83E442B1DEFF2A151B076962BE  : public Attribute_tFDA8EFEFB0711976D22474794576DAF28F7440AA
{
	String_t* ___attributeName;
};
struct XmlElementAttribute_t1E2EE1E1AB1D03CA9BD7774A39E44D81C649BDD5  : public Attribute_tFDA8EFEFB0711976D22474794576DAF28F7440AA
{
	String_t* ___elementName;
};
struct XmlIgnoreAttribute_tF75E291BD9B9092629821783096CBA98748F5C3F  : public Attribute_tFDA8EFEFB0711976D22474794576DAF28F7440AA
{
};
struct String_t_StaticFields
{
	String_t* ___Empty;
};
struct XmlReader_t4C709DEF5F01606ECB60B638F1BD6F6E0A9116FD_StaticFields
{
	uint32_t ___IsTextualNodeBitmap;
	uint32_t ___CanReadContentAsBitmap;
	uint32_t ___HasValueBitmap;
};
#ifdef __clang__
#pragma clang diagnostic pop
#endif



#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void XmlReader__cctor_m9FF3BD38D3644E099B8305E251679A77A0DF493E (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&XmlReader_t4C709DEF5F01606ECB60B638F1BD6F6E0A9116FD_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		((XmlReader_t4C709DEF5F01606ECB60B638F1BD6F6E0A9116FD_StaticFields*)il2cpp_codegen_static_fields_for(XmlReader_t4C709DEF5F01606ECB60B638F1BD6F6E0A9116FD_il2cpp_TypeInfo_var))->___IsTextualNodeBitmap = ((int32_t)24600);
		((XmlReader_t4C709DEF5F01606ECB60B638F1BD6F6E0A9116FD_StaticFields*)il2cpp_codegen_static_fields_for(XmlReader_t4C709DEF5F01606ECB60B638F1BD6F6E0A9116FD_il2cpp_TypeInfo_var))->___CanReadContentAsBitmap = ((int32_t)123324);
		((XmlReader_t4C709DEF5F01606ECB60B638F1BD6F6E0A9116FD_StaticFields*)il2cpp_codegen_static_fields_for(XmlReader_t4C709DEF5F01606ECB60B638F1BD6F6E0A9116FD_il2cpp_TypeInfo_var))->___HasValueBitmap = ((int32_t)157084);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* XmlAttributeAttribute_get_AttributeName_mD12BFE7D2970617D6BAEA2C7726BFCC1E78043B9 (XmlAttributeAttribute_t157535EDD908EB83E442B1DEFF2A151B076962BE* __this, const RuntimeMethod* method) 
{
	{
		String_t* L_0 = __this->___attributeName;
		if (L_0)
		{
			goto IL_000e;
		}
	}
	{
		String_t* L_1 = ((String_t_StaticFields*)il2cpp_codegen_static_fields_for(il2cpp_defaults.string_class))->___Empty;
		return L_1;
	}

IL_000e:
	{
		String_t* L_2 = __this->___attributeName;
		return L_2;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* XmlElementAttribute_get_ElementName_mFD5C95EC3061DC2A2D88E0EACC2DDFFA91C76F6F (XmlElementAttribute_t1E2EE1E1AB1D03CA9BD7774A39E44D81C649BDD5* __this, const RuntimeMethod* method) 
{
	{
		String_t* L_0 = __this->___elementName;
		if (L_0)
		{
			goto IL_000e;
		}
	}
	{
		String_t* L_1 = ((String_t_StaticFields*)il2cpp_codegen_static_fields_for(il2cpp_defaults.string_class))->___Empty;
		return L_1;
	}

IL_000e:
	{
		String_t* L_2 = __this->___elementName;
		return L_2;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif
