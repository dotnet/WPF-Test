<?xml version="1.0" encoding="utf-16"?>
<IteModel iteVersion="MDEModel_2.1_" sourceTool="MDE" sourceModelPath=""  modelName="PropertyChangeCallBack" label="PropertyChangeCallBack" sourceBinaryPath="" replacedInvalidIdentifiers="true" automated="false" referenceID="113c6c55-5f86-4cc7-89fd-8919a283c926" comment="" previewMode="false" stateBasedTestGeneration="1" xmlns="http://mbt.ntdev.corp.microsoft.com/mde/MDEModel_2.1_.xsd">
    <StateVariables referenceID="6258db58-47e0-4360-8218-dbb26786d32b">
        <StateVariable key_Name="Registered" label="Registered" comment="" dataGenerationType="" dataGenerationValue="" includeInClusters="true" isNumericInModel="false" uiPersistentID="" uiPattern="" uiProperty="" referenceID="897bc0bd-950b-452e-bafb-eeaea67bdb2d">
            <StateVariableValue key_Name="False" label="False" weight="1" includeInGenerationType="1" resultWeight="1" comment="" valid="true" uiPersistentID="" referenceID="9c61ab3d-22a0-451c-b234-8a8b308f13c5" />
            <StateVariableValue key_Name="True" label="True" weight="1" includeInGenerationType="1" resultWeight="1" comment="" valid="true" uiPersistentID="" referenceID="a640c02f-4dd0-4a7f-bf5f-979f8598401c" />
            <StateVariableValue key_Name="Readonly" label="Readonly" weight="1" includeInGenerationType="1" resultWeight="1" comment="" valid="true" uiPersistentID="" referenceID="de63a705-b45d-4015-ae29-77035f5cafb4" />
        </StateVariable>
        <StateVariable key_Name="Value" label="Value" comment="" dataGenerationType="" dataGenerationValue="" includeInClusters="true" isNumericInModel="false" uiPersistentID="" uiPattern="" uiProperty="" referenceID="40ac2836-c953-46e1-b361-d8233bb5e692">
            <StateVariableValue key_Name="None" label="None" weight="1" includeInGenerationType="1" resultWeight="1" comment="" valid="true" uiPersistentID="" referenceID="42608321-210a-4a2f-b46e-4a2d11c3b6ad" />
            <StateVariableValue key_Name="Set" label="Set" weight="1" includeInGenerationType="1" resultWeight="1" comment="" valid="true" uiPersistentID="" referenceID="e0fb5d76-5bfd-416a-aaa0-99f9d9051992" />
        </StateVariable>
        <StateVariable key_Name="ClearEmptyException" label="ClearEmptyException" comment="" dataGenerationType="" dataGenerationValue="" includeInClusters="true" isNumericInModel="false" uiPersistentID="" uiPattern="" uiProperty="" referenceID="89855e17-b5c2-43c5-9230-e3ec01e8642b">
            <StateVariableValue key_Name="False" label="False" weight="1" includeInGenerationType="1" resultWeight="1" comment="" valid="true" uiPersistentID="" referenceID="793b3bca-5cd7-449c-8b10-b8605a03817e" />
            <StateVariableValue key_Name="True" label="True" weight="1" includeInGenerationType="1" resultWeight="1" comment="" valid="true" uiPersistentID="" referenceID="e5c24553-ad96-41a9-bcdb-42b50aec7084" />
        </StateVariable>
        <StateVariable key_Name="SetTwiceExcpetion" label="SetTwiceExcpetion" comment="" dataGenerationType="" dataGenerationValue="" includeInClusters="true" isNumericInModel="false" uiPersistentID="" uiPattern="" uiProperty="" referenceID="7d4072d4-5635-4656-86c7-d8157f181b7a">
            <StateVariableValue key_Name="False" label="False" weight="1" includeInGenerationType="1" resultWeight="1" comment="" valid="true" uiPersistentID="" referenceID="b594360e-3c06-4608-880e-e8cf26c3b7b2" />
            <StateVariableValue key_Name="True" label="True" weight="1" includeInGenerationType="1" resultWeight="1" comment="" valid="true" uiPersistentID="" referenceID="7bb92c09-7773-400b-9479-67224afe4c84" />
        </StateVariable>
        <StateVariable key_Name="SetReadOnlyException" label="SetReadOnlyException" comment="" dataGenerationType="" dataGenerationValue="" includeInClusters="true" isNumericInModel="false" uiPersistentID="" uiPattern="" uiProperty="" referenceID="23f2aa46-f6ab-4304-9435-3cd0f0f24a29">
            <StateVariableValue key_Name="False" label="False" weight="1" includeInGenerationType="1" resultWeight="1" comment="" valid="true" uiPersistentID="" referenceID="132a746f-9f7c-4743-a2c7-e4e414db2c05" />
            <StateVariableValue key_Name="True" label="True" weight="1" includeInGenerationType="1" resultWeight="1" comment="" valid="true" uiPersistentID="" referenceID="131cf20c-6d33-4428-81b0-d83e0a61a1c7" />
        </StateVariable>
        <StateVariable key_Name="ClearReadOnlyException" label="ClearReadOnlyException" comment="" dataGenerationType="" dataGenerationValue="" includeInClusters="true" isNumericInModel="false" uiPersistentID="" uiPattern="" uiProperty="" referenceID="366fdc04-57ea-4f08-980e-0bae82595bff">
            <StateVariableValue key_Name="False" label="False" weight="1" includeInGenerationType="1" resultWeight="1" comment="" valid="true" uiPersistentID="" referenceID="96fd550e-4d19-49ab-afad-40295a10abd4" />
            <StateVariableValue key_Name="True" label="True" weight="1" includeInGenerationType="1" resultWeight="1" comment="" valid="true" uiPersistentID="" referenceID="cc726b49-b8e8-4175-a2f2-29b20bf96053" />
        </StateVariable>
    </StateVariables>
    <ModelParameters referenceID="3defbf4f-56b1-4ab9-af66-0292d6aa8270">
        <Parameters referenceID="4aec1c5b-9cfb-4423-926e-bf89d082d252">
            <Parameter key_Name="RegistrationType" label="RegistrationType" key_ActionReferenceID="8ca96e4b-88af-42cc-9d83-84dbc0c83eab" comment="" dataType="" dataGenerationType="" dataGenerationValue="" includeInGeneration="true" includeInClusters="true" automated="false" isNumericInModel="false" inOutType="0" uiPersistentID="" hidden="false" persist="false" referenceID="9d34107f-8761-40f6-a1c1-194cb81b11ac">
                <ParameterValue key_Name="Regular" label="Regular" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="9677605d-81f1-473d-81a0-6e83f7850221" />
                <ParameterValue key_Name="Attached" label="Attached" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="27941f5d-5f04-4440-a7a6-da1d165ea06a" />
            </Parameter>
            <Parameter key_Name="ReadOnly" label="ReadOnly" key_ActionReferenceID="8ca96e4b-88af-42cc-9d83-84dbc0c83eab" comment="" dataType="" dataGenerationType="" dataGenerationValue="" includeInGeneration="true" includeInClusters="true" automated="false" isNumericInModel="false" inOutType="0" uiPersistentID="" hidden="false" persist="false" referenceID="fe406e76-264a-4702-b3aa-745e7c6fcb6d">
                <ParameterValue key_Name="True" label="True" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="29c49b87-ccf2-45d0-a75c-883e5701c1ed" />
                <ParameterValue key_Name="False" label="False" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="f2f37508-512c-4de8-8712-8fdf1976253d" />
            </Parameter>
            <Parameter key_Name="PropertyType" label="PropertyType" key_ActionReferenceID="8ca96e4b-88af-42cc-9d83-84dbc0c83eab" comment="" dataType="" dataGenerationType="" dataGenerationValue="" includeInGeneration="true" includeInClusters="true" automated="false" isNumericInModel="false" inOutType="0" uiPersistentID="" hidden="false" persist="false" referenceID="b484e287-18dd-477c-b27b-fe193bcd1225">
                <ParameterValue key_Name="String" label="String" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="8de60037-f3f8-453f-bd97-e5f479dd6345" />
                <ParameterValue key_Name="Double" label="Double" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="2c0efa0c-cd10-4a8c-86d8-cae0587daa8b" />
                <ParameterValue key_Name="Class" label="Class" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="8fa7415a-3cd7-48c6-8de9-10e678c41be7" />
                <ParameterValue key_Name="Struct" label="Struct" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="3912529e-73bd-48ff-9980-693006eedd06" />
            </Parameter>
            <Parameter key_Name="MetaData" label="MetaData" key_ActionReferenceID="8ca96e4b-88af-42cc-9d83-84dbc0c83eab" comment="" dataType="" dataGenerationType="" dataGenerationValue="" includeInGeneration="true" includeInClusters="true" automated="false" isNumericInModel="false" inOutType="0" uiPersistentID="" hidden="false" persist="false" referenceID="a15f9ce6-874a-4947-88e4-abc451d0dace">
                <ParameterValue key_Name="None" label="None" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="06a57d2a-45d6-4c62-870c-a8dd42bec63d" />
                <ParameterValue key_Name="Regular" label="Regular" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="b4c6f692-75ac-4828-a7f8-b9290712814a" />
                <ParameterValue key_Name="Coerced" label="Coerced" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="226347dc-183f-4eba-84f5-aa89b241e3b5" />
                <ParameterValue key_Name="Derived" label="Derived" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="eda86c69-1b10-4986-8477-4451f820f6a1" />
            </Parameter>
            <Parameter key_Name="NewVal" label="NewVal" key_ActionReferenceID="4e006cdc-fee5-4215-8232-8e543dd3ff8f" comment="" dataType="" dataGenerationType="" dataGenerationValue="" includeInGeneration="true" includeInClusters="true" automated="false" isNumericInModel="false" inOutType="0" uiPersistentID="" hidden="false" persist="false" referenceID="edd4311f-b3fb-4bb2-b08a-22e046742e2c">
                <ParameterValue key_Name="None" label="None" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="5fec367e-a483-4591-ad8d-eb25c3c972aa" />
                <ParameterValue key_Name="Default" label="Default" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="aed1b1d2-5325-4c98-bfa9-f6f416ed5be6" />
                <ParameterValue key_Name="Derived" label="Derived" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="9b9f51e8-a2fe-4e5a-83d7-49c433a236e6" />
                <ParameterValue key_Name="Custom" label="Custom" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="89aa962e-c51a-4344-ae9a-d19f2a7b4ce8" />
                <ParameterValue key_Name="Repeat" label="Repeat" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="a0908aeb-8815-4a18-af5c-c455df8aa905" />
                <ParameterValue key_Name="CallsCoerce" label="CallsCoerce" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="23fa0fe2-76ad-43ac-aa29-766c4e3f8b5c" />
            </Parameter>
            <Parameter key_Name="TargetType" label="TargetType" key_ActionReferenceID="8ca96e4b-88af-42cc-9d83-84dbc0c83eab" comment="" dataType="" dataGenerationType="" dataGenerationValue="" includeInGeneration="true" includeInClusters="true" automated="false" isNumericInModel="false" inOutType="0" uiPersistentID="" hidden="false" persist="false" referenceID="2cb9cd53-84d3-4bb8-9b2e-988231094d4f">
                <ParameterValue key_Name="Self" label="Self" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="82734583-4cfa-46bf-9862-2dc72faddfc8" />
                <ParameterValue key_Name="BaseClass" label="BaseClass" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="d0fd17b1-6ddf-4e63-aac1-f262062cf80e" />
                <ParameterValue key_Name="Other" label="Other" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="f2c24938-bfa7-49d0-8adb-294c279f45aa" />
                <ParameterValue key_Name="OtherDO" label="OtherDO" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="7142a8b6-9a49-4c45-ad90-22ed78c2c349" />
            </Parameter>
        </Parameters>
        <ParameterCombinationRules seed="1" referenceID="3389b692-9eb2-49c5-8b75-6022654142b0">
            <ParameterCluster key_Name="Pairwise" label="Pairwise" comment="" combinatoryType="3" include="true" combinatoryOrder="2" referenceID="183deb1c-3ca8-42c4-94ee-d05739b0f57c">
                <ParameterClusterElement key_ParameterReferenceID="9d34107f-8761-40f6-a1c1-194cb81b11ac" key_ModelReferenceID="" referenceID="ddf0cdda-584c-4a3d-bdc7-c7d7595e8070" />
                <ParameterClusterElement key_ParameterReferenceID="fe406e76-264a-4702-b3aa-745e7c6fcb6d" key_ModelReferenceID="" referenceID="b33a7512-866a-4002-bd44-664d7a8ceeca" />
                <ParameterClusterElement key_ParameterReferenceID="b484e287-18dd-477c-b27b-fe193bcd1225" key_ModelReferenceID="" referenceID="74331222-f456-4eb8-937e-6b1994099027" />
                <ParameterClusterElement key_ParameterReferenceID="2cb9cd53-84d3-4bb8-9b2e-988231094d4f" key_ModelReferenceID="" referenceID="2b464391-12c3-4bfe-8cbc-60ba4becc8d7" />
                <ParameterClusterElement key_ParameterReferenceID="a15f9ce6-874a-4947-88e4-abc451d0dace" key_ModelReferenceID="" referenceID="a2c5bca5-b0f9-45cc-9e72-0a4b8d9b65b1" />
            </ParameterCluster>
        </ParameterCombinationRules>
    </ModelParameters>
    <Actions referenceID="1d8d2544-99d0-4401-98fd-039c1dcc06d6">
        <Action key_Name="SetUp" label="SetUp" comment="" weight="1" disabled="false" defaultClusterReferenceID="" uiPersistentID="" uiPattern="" uiMethod="" automated="false" referenceID="8ca96e4b-88af-42cc-9d83-84dbc0c83eab">
            <ActionParameters referenceID="fc2f56c4-05e1-4e70-a36e-383b5bda79ee">
                <ActionParameter key_ActionParameterReferenceID="9d34107f-8761-40f6-a1c1-194cb81b11ac" referenceID="1780a459-394d-483f-8ce3-ad100f6bfbe5" />
                <ActionParameter key_ActionParameterReferenceID="fe406e76-264a-4702-b3aa-745e7c6fcb6d" referenceID="c640cbbd-9cc3-4fde-a32e-034576119992" />
                <ActionParameter key_ActionParameterReferenceID="b484e287-18dd-477c-b27b-fe193bcd1225" referenceID="d951201a-9daf-4ba3-85c2-38a762705f56" />
                <ActionParameter key_ActionParameterReferenceID="2cb9cd53-84d3-4bb8-9b2e-988231094d4f" referenceID="8d52e2ce-35cf-4891-8a5a-116dc226afa4" />
                <ActionParameter key_ActionParameterReferenceID="a15f9ce6-874a-4947-88e4-abc451d0dace" referenceID="3023ef9c-7bbb-4824-8259-ace01113d232" />
            </ActionParameters>
        </Action>
        <Action key_Name="SetPropertyValue" label="SetPropertyValue" comment="" weight="1" disabled="false" defaultClusterReferenceID="" uiPersistentID="" uiPattern="" uiMethod="" automated="false" referenceID="4e006cdc-fee5-4215-8232-8e543dd3ff8f">
            <ActionParameters referenceID="9240c1a1-e90d-4dd1-8352-7261a799a3b5">
                <ActionParameter key_ActionParameterReferenceID="edd4311f-b3fb-4bb2-b08a-22e046742e2c" referenceID="fe8386de-ec07-4c82-bd78-f310bc2b6791" />
            </ActionParameters>
        </Action>
        <Action key_Name="ClearPropertyValue" label="ClearPropertyValue" comment="" weight="1" disabled="false" defaultClusterReferenceID="" uiPersistentID="" uiPattern="" uiMethod="" automated="false" referenceID="fbb7bfdf-c2b7-4c88-b8aa-f68596831120" />
    </Actions>
    <TransitionRules referenceID="834c5c7f-44ed-4b35-916d-87cc3cdffae0">
        <TransitionRule key_RuleID="TR_0" actionReferenceID="8ca96e4b-88af-42cc-9d83-84dbc0c83eab" name="Register" label="Register" weight="1" comment="" ruleCode="if (Registered = False)&#xA;then&#xA;	Registered = True;&#xA;endif&#xA;" disabled="false" ruleType="0" functionCount="1" comparesParameter="false" assignsParameterToState="false" referenceID="145d7fb2-056b-4d8c-b99d-a19114e1f638">
            <TransitionRuleDependencies key_dependencyReferenceID="897bc0bd-950b-452e-bafb-eeaea67bdb2d" referenceID="57277ddd-3271-43f3-a85b-4688a2cca940" />
            <TransitionRuleDependencies key_dependencyReferenceID="9c61ab3d-22a0-451c-b234-8a8b308f13c5" referenceID="153d401a-5397-46a2-a72d-1197852571cb" />
            <TransitionRuleDependencies key_dependencyReferenceID="a640c02f-4dd0-4a7f-bf5f-979f8598401c" referenceID="1de9d72d-6109-4e15-b660-48ecfd627dd7" />
        </TransitionRule>
        <TransitionRule key_RuleID="TR_1" actionReferenceID="4e006cdc-fee5-4215-8232-8e543dd3ff8f" name="SetValue" label="SetValue" weight="1" comment="" ruleCode="&#xA;if ((Registered = True) and (Value = None))&#xA;then&#xA;	Value = Set;&#xA;endif" disabled="false" ruleType="0" functionCount="1" comparesParameter="false" assignsParameterToState="false" referenceID="0c61663c-f01e-4052-93e6-188b6872247f">
            <TransitionRuleDependencies key_dependencyReferenceID="897bc0bd-950b-452e-bafb-eeaea67bdb2d" referenceID="7a4cc9d2-4fc3-418a-8419-4937e36ac8f0" />
            <TransitionRuleDependencies key_dependencyReferenceID="a640c02f-4dd0-4a7f-bf5f-979f8598401c" referenceID="9ae57884-1ce2-4517-8a5d-781b4ebc2813" />
            <TransitionRuleDependencies key_dependencyReferenceID="40ac2836-c953-46e1-b361-d8233bb5e692" referenceID="713e7f7c-e13d-431a-8755-b0bfd5dc44d9" />
            <TransitionRuleDependencies key_dependencyReferenceID="42608321-210a-4a2f-b46e-4a2d11c3b6ad" referenceID="a43e0abf-b001-4e4c-bb3e-a6665b38c32a" />
            <TransitionRuleDependencies key_dependencyReferenceID="e0fb5d76-5bfd-416a-aaa0-99f9d9051992" referenceID="a4770a2d-36e8-4e3b-aae1-69429978b468" />
        </TransitionRule>
        <TransitionRule key_RuleID="TR_2" actionReferenceID="fbb7bfdf-c2b7-4c88-b8aa-f68596831120" name="ClearValue" label="ClearValue" weight="1" comment="" ruleCode="&#xA;if ((Registered = True) and (Value = Set))&#xA;then&#xA;	Value = None;&#xA;endif" disabled="false" ruleType="0" functionCount="1" comparesParameter="false" assignsParameterToState="false" referenceID="8844992f-8b4c-4617-b7b1-f972a457562a">
            <TransitionRuleDependencies key_dependencyReferenceID="897bc0bd-950b-452e-bafb-eeaea67bdb2d" referenceID="edfa7e14-309c-48d5-9225-4577e5d2be70" />
            <TransitionRuleDependencies key_dependencyReferenceID="a640c02f-4dd0-4a7f-bf5f-979f8598401c" referenceID="26ffc763-30ff-43d2-b056-b2e9c7e52aaf" />
            <TransitionRuleDependencies key_dependencyReferenceID="40ac2836-c953-46e1-b361-d8233bb5e692" referenceID="64ef758d-d9a9-4dbd-80b8-70de47ff0781" />
            <TransitionRuleDependencies key_dependencyReferenceID="e0fb5d76-5bfd-416a-aaa0-99f9d9051992" referenceID="2e389863-1cda-4679-bc7d-0597197fed19" />
            <TransitionRuleDependencies key_dependencyReferenceID="42608321-210a-4a2f-b46e-4a2d11c3b6ad" referenceID="4aba6cce-32e6-40cf-8deb-2c7a7a61805b" />
        </TransitionRule>
        <TransitionRule key_RuleID="TR_3" actionReferenceID="fbb7bfdf-c2b7-4c88-b8aa-f68596831120" name="ClearEmptyValue" label="ClearEmptyValue" weight="1" comment="" ruleCode="if ((Registered = True) and (Value = None))&#xA;then&#xA;	ClearEmptyException = True;&#xA;endif" disabled="false" ruleType="0" functionCount="1" comparesParameter="false" assignsParameterToState="false" referenceID="1be65577-bb45-4f12-b0fd-25384c8899f3">
            <TransitionRuleDependencies key_dependencyReferenceID="89855e17-b5c2-43c5-9230-e3ec01e8642b" referenceID="c6e2cf3b-1e97-4559-b9db-0967937ff968" />
            <TransitionRuleDependencies key_dependencyReferenceID="e5c24553-ad96-41a9-bcdb-42b50aec7084" referenceID="45c2913b-83b8-4d3a-9260-3e9128fc2185" />
            <TransitionRuleDependencies key_dependencyReferenceID="897bc0bd-950b-452e-bafb-eeaea67bdb2d" referenceID="cefeee5d-e87c-4b61-9761-ebd58b251c50" />
            <TransitionRuleDependencies key_dependencyReferenceID="a640c02f-4dd0-4a7f-bf5f-979f8598401c" referenceID="f97e3240-4df6-4018-a47b-b43265200a18" />
            <TransitionRuleDependencies key_dependencyReferenceID="40ac2836-c953-46e1-b361-d8233bb5e692" referenceID="0bcf23b4-8e9a-4609-a2fc-7bb9719b8bcc" />
            <TransitionRuleDependencies key_dependencyReferenceID="42608321-210a-4a2f-b46e-4a2d11c3b6ad" referenceID="9d11cf3e-9960-4905-95f8-c5778c1d0efe" />
        </TransitionRule>
        <TransitionRule key_RuleID="TR_4" actionReferenceID="fbb7bfdf-c2b7-4c88-b8aa-f68596831120" name="ClearReadOnly" label="ClearReadOnly" weight="1" comment="" ruleCode="if ((Registered = True) and (Setup.Readonly = True))&#xA;then&#xA;	ClearReadOnlyExcpetion = True;&#xA;endif" disabled="false" ruleType="0" functionCount="1" comparesParameter="false" assignsParameterToState="false" referenceID="237f823c-1a8e-4339-ad99-d752dec73023" />
    </TransitionRules>
    <EntryPoints seed="1" referenceID="9211418e-be05-4240-a8bb-ab15cb2fa353">
        <EntryPointCustomCombinations ruleBased="true" comment="" name="Default" label="Default" referenceID="5d507d2a-882b-4891-9116-58bbb7e07fd5">
            <EntryPointCustomCombination key_EntryPointNameReferenceID="897bc0bd-950b-452e-bafb-eeaea67bdb2d" entryPointValueReferenceID="9c61ab3d-22a0-451c-b234-8a8b308f13c5" referenceID="e4c6f7e7-d116-44b6-9d5e-a04b72caa12e" />
            <EntryPointCustomCombination key_EntryPointNameReferenceID="40ac2836-c953-46e1-b361-d8233bb5e692" entryPointValueReferenceID="42608321-210a-4a2f-b46e-4a2d11c3b6ad" referenceID="80a2cc80-963a-44d0-8d84-e137e54d3305" />
            <EntryPointCustomCombination key_EntryPointNameReferenceID="89855e17-b5c2-43c5-9230-e3ec01e8642b" entryPointValueReferenceID="793b3bca-5cd7-449c-8b10-b8605a03817e" referenceID="cf357175-8319-4645-a455-77fcd3e9de9e" />
            <EntryPointCustomCombination key_EntryPointNameReferenceID="7d4072d4-5635-4656-86c7-d8157f181b7a" entryPointValueReferenceID="b594360e-3c06-4608-880e-e8cf26c3b7b2" referenceID="f550c13b-9231-441c-bb33-b0f8936b5a02" />
            <EntryPointCustomCombination key_EntryPointNameReferenceID="23f2aa46-f6ab-4304-9435-3cd0f0f24a29" entryPointValueReferenceID="132a746f-9f7c-4743-a2c7-e4e414db2c05" referenceID="b44adb7c-128b-4ab0-a4a4-fe26186d1cab" />
            <EntryPointCustomCombination key_EntryPointNameReferenceID="366fdc04-57ea-4f08-980e-0bae82595bff" entryPointValueReferenceID="96fd550e-4d19-49ab-afad-40295a10abd4" referenceID="0f521083-9d4a-4ac1-a543-a81a60a493f1" />
        </EntryPointCustomCombinations>
    </EntryPoints>
    <AssertionRules referenceID="9fb0cec8-a912-491e-8689-4cc57bbc86ba" />
    <ModelInfo overview="" constructionInfo="" referenceID="4b90dff4-9da8-4255-b381-04d3db22ed8e" />
    <ModelReferences referenceID="e5cc223c-cdde-4c83-99a4-ff426779e5c8" />
    <ModelLinkRules referenceID="8938450f-ba77-49e4-9158-153cb2b2a7ee" />
    <TestQueries referenceID="b72822da-ce36-496d-82ad-af01d0646ff3">
        <TestQuery key_Name="TestRun" label="TestRun" testOutputFilePathName="&lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-16&quot;?&gt;&#xD;&#xA;&lt;StandAloneLocation xmlns:xsd=&quot;http://www.w3.org/2001/XMLSchema&quot; xmlns:xsi=&quot;http://www.w3.org/2001/XMLSchema-instance&quot;&gt;&#xD;&#xA;  &lt;ModelPathName&gt;D:\NT\testsrc\windowstestdata\redist\client\wcptests\core\bvt\propertyengine\PropertyChanged\CallBackVerificationModel.mbt&lt;/ModelPathName&gt;&#xD;&#xA;  &lt;TestCaseFileName&gt;D:\NT\testsrc\windowstestdata\redist\client\wcptests\core\bvt\propertyengine\PropertyChanged\PropertyChange.xtc&lt;/TestCaseFileName&gt;&#xD;&#xA;&lt;/StandAloneLocation&gt;" comment="" isStateless="true" referenceID="ed1a065f-a66b-4442-9cb2-9babff7a1eb9" maxTestCases="2000" applyFilters="true" testOutputLocationType="Microsoft.Ite.StandAloneInterface.StandAloneLocation,Microsoft.Ite.StandAloneTcmInterface, Version=2.1.2005.0, Culture=neutral, PublicKeyToken=null~" externalDataXml="" externalDataType="" disabled="false">
            <TestPattern seed="1" referenceID="0a776e01-5d47-4a00-9731-47788c6fbedc">
                <TestPatternElement testPatternElementType="0" modelReferenceID="113c6c55-5f86-4cc7-89fd-8919a283c926" referenceID="f7d95121-c420-4f9f-8e12-54b07dec6ba1">
                    <ActionTestPatternElement actionReferenceID="8ca96e4b-88af-42cc-9d83-84dbc0c83eab" referenceID="7ae48adc-0d4e-4cd9-bad7-4347ae92ef10" />
                </TestPatternElement>
                <TestPatternElement testPatternElementType="0" modelReferenceID="113c6c55-5f86-4cc7-89fd-8919a283c926" referenceID="d1d1cb49-7f29-49ac-907e-eafd221784e6">
                    <ActionTestPatternElement actionReferenceID="4e006cdc-fee5-4215-8232-8e543dd3ff8f" referenceID="a0584f1d-c9e6-470d-b214-2efd17bba624" />
                </TestPatternElement>
                <TestPatternElement testPatternElementType="0" modelReferenceID="113c6c55-5f86-4cc7-89fd-8919a283c926" referenceID="8706112a-dec0-49ce-8d4e-f74dd3781201">
                    <ActionTestPatternElement actionReferenceID="fbb7bfdf-c2b7-4c88-b8aa-f68596831120" referenceID="ae5adcea-ef75-4163-a7f8-6b8b14f5407b" />
                </TestPatternElement>
            </TestPattern>
        </TestQuery>
    </TestQueries>
    <TestFilters referenceID="d32d9332-bc47-4ed2-9def-3b385542affd" />
    <CustomData referenceID="ffdbf81f-af7a-4585-9bc4-8243e415bd17" />
</IteModel>