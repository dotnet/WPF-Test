<?xml version="1.0" encoding="utf-16"?>
<IteModel iteVersion="MDEModel_2.1_" sourceTool="MDE" sourceModelPath=""  modelName="DispatcherHooksInstance" label="DispatcherHooksInstance" sourceBinaryPath="" replacedInvalidIdentifiers="false" automated="false" referenceID="33ef82ef-6d25-4d97-96e2-78a1b392d54b" comment="" previewMode="false" stateBasedTestGeneration="1" xmlns="http://mbt.ntdev.corp.microsoft.com/mde/MDEModel_2.1_.xsd">
    <StateVariables referenceID="46cd6d9f-f416-4c76-994c-9fc66cb864ea" />
    <ModelParameters referenceID="e30ffd41-7bc6-46f7-ab1f-87d2817fdbb1">
        <Parameters referenceID="a5f281ad-d363-4d7a-9413-4d3d94131321">
            <Parameter key_Name="NumOfDispatcher" label="NumOfDispatcher" key_ActionReferenceID="44bdabe2-94bc-4f48-976f-45b7f13b3b15" comment="" dataType="" dataGenerationType="" dataGenerationValue="" includeInGeneration="true" includeInClusters="true" automated="false" isNumericInModel="true" inOutType="0" uiPersistentID="" hidden="false" persist="false" referenceID="dd51a656-25c0-40b9-9750-c877f24816b8">
                <ParameterValue key_Name="1" label="1" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="42d4e6ab-6801-4e23-a8fb-b8811af43897" />
                <ParameterValue key_Name="3" label="3" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="a9373bad-0917-4312-bbfa-6482ebaba731" />
            </Parameter>
            <Parameter key_Name="NumOfReading" label="NumOfReading" key_ActionReferenceID="44bdabe2-94bc-4f48-976f-45b7f13b3b15" comment="" dataType="" dataGenerationType="" dataGenerationValue="" includeInGeneration="true" includeInClusters="true" automated="false" isNumericInModel="true" inOutType="0" uiPersistentID="" hidden="false" persist="false" referenceID="8f165428-e853-4c91-a491-a95a17167689">
                <ParameterValue key_Name="1" label="1" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="4a463223-fb86-4377-991d-9a8e9faa8d03" />
                <ParameterValue key_Name="5" label="5" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="ec4482fa-40c9-4469-b925-9c73aa00615c" />
            </Parameter>
            <Parameter key_Name="DispatcherTypeSeed" label="DispatcherTypeSeed" key_ActionReferenceID="44bdabe2-94bc-4f48-976f-45b7f13b3b15" comment="" dataType="" dataGenerationType="" dataGenerationValue="" includeInGeneration="true" includeInClusters="true" automated="false" isNumericInModel="true" inOutType="0" uiPersistentID="" hidden="false" persist="false" referenceID="f914a7c8-cb58-47ca-8b52-1c5a7e118b80">
                <ParameterValue key_Name="2" label="2" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="71bc0aa5-f19b-40c7-ac0d-08e0c9dd3470" />
                <ParameterValue key_Name="3" label="3" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="21847665-c67f-46c4-80fd-ca3057ce239f" />
                <ParameterValue key_Name="4" label="4" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="3cf98ac6-1c30-465f-8be3-cf2fa6645065" />
            </Parameter>
        </Parameters>
        <ParameterCombinationRules seed="1" referenceID="205fde82-619d-4d39-8aa2-84d20e4f5347">
            <ParameterCluster key_Name="CombinationGroup# 0" label="CombinationGroup# 0" comment="" combinatoryType="0" include="true" combinatoryOrder="0" referenceID="e9a3705b-52bc-4c36-beb9-f7cd4e351d01">
                <ParameterClusterElement key_ParameterReferenceID="dd51a656-25c0-40b9-9750-c877f24816b8" key_ModelReferenceID="" referenceID="800e7258-14b3-4b8c-85ff-810b3cdffddf" />
                <ParameterClusterElement key_ParameterReferenceID="8f165428-e853-4c91-a491-a95a17167689" key_ModelReferenceID="" referenceID="e5c022ac-a27a-4340-875b-2686e1ce25af" />
            </ParameterCluster>
        </ParameterCombinationRules>
    </ModelParameters>
    <Actions referenceID="ac40c3df-7f75-4901-be1b-f924e627e267">
        <Action key_Name="SetupTest" label="SetupTest" comment="" weight="1" disabled="false" defaultClusterReferenceID="" uiPersistentID="" uiPattern="" uiMethod="" automated="false" referenceID="44bdabe2-94bc-4f48-976f-45b7f13b3b15">
            <ActionParameters referenceID="f60acaa5-e451-4166-95bb-3f769226b717">
                <ActionParameter key_ActionParameterReferenceID="dd51a656-25c0-40b9-9750-c877f24816b8" referenceID="f15c45ab-5704-4a53-872d-dc11cc82a064" />
                <ActionParameter key_ActionParameterReferenceID="8f165428-e853-4c91-a491-a95a17167689" referenceID="9c612207-94ac-43b7-8f6f-f7fb59c3e114" />
                <ActionParameter key_ActionParameterReferenceID="f914a7c8-cb58-47ca-8b52-1c5a7e118b80" referenceID="0326c365-9bf4-4db4-8883-1f303a97298c" />
            </ActionParameters>
        </Action>
    </Actions>
    <TransitionRules referenceID="7e3f9c4d-1a6f-4e95-9f22-4e03b55bc97f" />
    <EntryPoints seed="1" referenceID="336add14-0a01-4ec2-b1af-36f3f59f80cc" />
    <AssertionRules referenceID="b8bfb8b2-8843-4f67-ad42-74f11aabdcc5" />
    <ModelInfo overview="" constructionInfo="" referenceID="f1922984-08f8-47f3-ac72-d4d56c3d50fe" />
    <ModelReferences referenceID="d05f945f-1cc1-43d6-8aa2-380a74bc15de" />
    <ModelLinkRules referenceID="21f5f858-eea3-4e6f-b975-a33ff04b8bb1" />
    <TestQueries referenceID="97b4d996-267a-434f-8ff8-a3abe085b8dc">
        <TestQuery key_Name="All" label="All" testOutputFilePathName="&lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-16&quot;?&gt;&#xD;&#xA;&lt;StandAloneLocation xmlns:xsd=&quot;http://www.w3.org/2001/XMLSchema&quot; xmlns:xsi=&quot;http://www.w3.org/2001/XMLSchema-instance&quot;&gt;&#xD;&#xA;  &lt;ModelPathName&gt;E:\Documents and Settings\Microsoft\My Documents\DispatcherHooksInstance.mbt&lt;/ModelPathName&gt;&#xD;&#xA;  &lt;TestCaseFileName&gt;E:\Documents and Settings\Microsoft\My Documents\DispatcherHooksInstance.xtc&lt;/TestCaseFileName&gt;&#xD;&#xA;&lt;/StandAloneLocation&gt;" comment="" isStateless="true" referenceID="ee5eeb83-ec84-4a6c-8c4a-598c8a8e33c9" maxTestCases="0" applyFilters="true" testOutputLocationType="Microsoft.Ite.StandAloneInterface.StandAloneLocation,Microsoft.Ite.StandAloneTcmInterface, Version=2.1.2005.0, Culture=neutral, PublicKeyToken=null~" externalDataXml="" externalDataType="" disabled="false">
            <TestPattern seed="1" referenceID="f9142e93-382a-49d4-8688-9203faa9f0c6">
                <TestPatternElement testPatternElementType="0" modelReferenceID="33ef82ef-6d25-4d97-96e2-78a1b392d54b" referenceID="8eef72f7-d2e6-4cb0-868a-3f810c4a1bc4">
                    <ActionTestPatternElement actionReferenceID="44bdabe2-94bc-4f48-976f-45b7f13b3b15" referenceID="6a309ffa-1d47-4fde-94ec-0710a0468330">
                        <ParameterTestPatternElement key_ParameterReferenceID="dd51a656-25c0-40b9-9750-c877f24816b8" parameterValueReferenceID="" lowWeight="0" highWeight="0" validFilter="0" automatedFilter="0" bucketFilter="" referenceID="acd4bcb4-ea0f-48d9-bf0e-fd87cfd546e3" />
                        <ParameterTestPatternElement key_ParameterReferenceID="8f165428-e853-4c91-a491-a95a17167689" parameterValueReferenceID="" lowWeight="0" highWeight="0" validFilter="0" automatedFilter="0" bucketFilter="" referenceID="cd7ab0d3-6016-48f6-82a0-d019cf0074ed" />
                    </ActionTestPatternElement>
                </TestPatternElement>
            </TestPattern>
        </TestQuery>
    </TestQueries>
    <TestFilters referenceID="9d59538e-7806-48ed-bcfb-60376ae118e1" />
    <CustomData referenceID="4a761ebf-25d8-44e1-9df1-ba803e9c0107" />
</IteModel>