<?xml version="1.0" encoding="utf-16"?>
<IteModel iteVersion="MDEModel_2.1_" sourceTool="MDE" sourceModelPath=""  modelName="ComponentDispatcherModel" label="ComponentDispatcherModel" sourceBinaryPath="" replacedInvalidIdentifiers="true" automated="false" referenceID="4d7a70ae-e65e-4269-9a31-f2d3291ca129" comment="" previewMode="false" stateBasedTestGeneration="1" xmlns="http://mbt.ntdev.corp.microsoft.com/mde/MDEModel_2.1_.xsd">
    <StateVariables referenceID="b7c6028e-0676-4013-a3a5-5f3537f99310" />
    <ModelParameters referenceID="1f52328f-bd35-411f-9054-4aec6d548212">
        <Parameters referenceID="88f6534e-87c7-4323-9449-824408f01bbf">
            <Parameter key_Name="TopLevel" label="TopLevel" key_ActionReferenceID="a96c1b7b-bd35-4299-8e8c-b9d623a7e932" comment="" dataType="" dataGenerationType="" dataGenerationValue="" includeInGeneration="true" includeInClusters="true" automated="false" isNumericInModel="false" inOutType="0" uiPersistentID="" hidden="false" persist="false" referenceID="435f67ef-2d49-436e-9014-9397e94906e4">
                <ParameterValue key_Name="Avalon" label="Avalon" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="4c3e8d24-7a97-408f-9afa-88b3068d2573" />
            </Parameter>
            <Parameter key_Name="Popup" label="Popup" key_ActionReferenceID="a96c1b7b-bd35-4299-8e8c-b9d623a7e932" comment="" dataType="" dataGenerationType="" dataGenerationValue="" includeInGeneration="true" includeInClusters="true" automated="false" isNumericInModel="false" inOutType="0" uiPersistentID="" hidden="false" persist="false" referenceID="84eef006-e3b4-41ac-9996-3099a4c5292e">
                <ParameterValue key_Name="Avalon" label="Avalon" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="6a6e4290-d3d2-4b06-b091-7f58baa672cf" />
                <ParameterValue key_Name="WinForm" label="WinForm" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="f90971aa-97e8-4710-823f-ec60378c9d9c" />
            </Parameter>
        </Parameters>
        <ParameterCombinationRules seed="1" referenceID="14479880-73d5-4f1b-b7a1-2a7a87f9a2b5">
            <ParameterCluster key_Name="CombinationGroup# 0" label="CombinationGroup# 0" comment="" combinatoryType="0" include="true" combinatoryOrder="0" referenceID="00c4bbec-44c1-4b84-8a53-9c98e69cd95e">
                <ParameterClusterElement key_ParameterReferenceID="435f67ef-2d49-436e-9014-9397e94906e4" key_ModelReferenceID="" referenceID="0109ac1b-9ee9-4eb0-8c44-ae2ccb182dbb" />
                <ParameterClusterElement key_ParameterReferenceID="84eef006-e3b4-41ac-9996-3099a4c5292e" key_ModelReferenceID="" referenceID="30f1f5c3-74ad-4093-82aa-3d7fc706775e" />
            </ParameterCluster>
        </ParameterCombinationRules>
    </ModelParameters>
    <Actions referenceID="5769eb88-ba43-40f0-9fde-f204c5baf16b">
        <Action key_Name="Run" label="Run" comment="" weight="1" disabled="false" defaultClusterReferenceID="" uiPersistentID="" uiPattern="" uiMethod="" automated="false" referenceID="a96c1b7b-bd35-4299-8e8c-b9d623a7e932">
            <ActionParameters referenceID="9a5568a9-fb6f-47bd-8d6d-eeacef5e2e4a">
                <ActionParameter key_ActionParameterReferenceID="435f67ef-2d49-436e-9014-9397e94906e4" referenceID="ed2642ea-eec4-486e-9322-67a4fe377d56" />
                <ActionParameter key_ActionParameterReferenceID="84eef006-e3b4-41ac-9996-3099a4c5292e" referenceID="1d12617d-1631-4dbd-b0da-4a060d7e9520" />
            </ActionParameters>
        </Action>
    </Actions>
    <TransitionRules referenceID="37b32e48-374f-4c80-b7b5-34705aaf664d" />
    <EntryPoints seed="1" referenceID="237ef1e6-8787-4b1b-8ced-9c357d7330d2" />
    <AssertionRules referenceID="ab2966d8-ffe1-43bb-99fb-c1e7c96102b5" />
    <ModelInfo overview="" constructionInfo="" referenceID="07699066-d532-46cf-8ddb-ead0c3321931" />
    <ModelReferences referenceID="bb5dd9b3-9516-4606-92e3-dca333b4204d" />
    <ModelLinkRules referenceID="5b7da079-2229-4dd3-aad8-f56aeb1593f8" />
    <TestQueries referenceID="7eed2449-139e-4e8e-8ef5-4f906d346a7a">
        <TestQuery key_Name="testComDisp" label="testComDisp" testOutputFilePathName="&lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-16&quot;?&gt;&#xD;&#xA;&lt;StandAloneLocation xmlns:xsd=&quot;http://www.w3.org/2001/XMLSchema&quot; xmlns:xsi=&quot;http://www.w3.org/2001/XMLSchema-instance&quot;&gt;&#xD;&#xA;  &lt;ModelPathName&gt;C:\Documents and Settings\Microsoft\My Documents\ComponentDispatcherModel.mbt&lt;/ModelPathName&gt;&#xD;&#xA;  &lt;TestCaseFileName&gt;C:\Documents and Settings\Microsoft\My Documents\ComponentDispatcher.xtc&lt;/TestCaseFileName&gt;&#xD;&#xA;&lt;/StandAloneLocation&gt;" comment="" isStateless="true" referenceID="0e7e4b5a-d9bd-49a5-8ae9-2f6a2d6e4776" maxTestCases="3" applyFilters="true" testOutputLocationType="Microsoft.Ite.StandAloneInterface.StandAloneLocation,Microsoft.Ite.StandAloneTcmInterface, Version=2.1.2005.0, Culture=neutral, PublicKeyToken=null~" externalDataXml="" externalDataType="" disabled="false">
            <TestPattern seed="1" referenceID="af3c37ec-6b5b-4881-978b-7d04f34ac668">
                <TestPatternElement testPatternElementType="0" modelReferenceID="4d7a70ae-e65e-4269-9a31-f2d3291ca129" referenceID="02830d67-ce94-4a57-bc34-8547448ee610">
                    <ActionTestPatternElement actionReferenceID="a96c1b7b-bd35-4299-8e8c-b9d623a7e932" referenceID="447b6190-c6a9-4d18-b6d8-67c6f35fd3b8" />
                </TestPatternElement>
            </TestPattern>
        </TestQuery>
    </TestQueries>
    <TestFilters referenceID="cf7a9276-11a2-4384-b136-5f41f943f407" />
    <CustomData referenceID="cf316088-6550-4c82-805e-49008e967785" />
</IteModel>