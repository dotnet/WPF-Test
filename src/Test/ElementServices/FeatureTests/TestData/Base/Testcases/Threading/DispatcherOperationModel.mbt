<?xml version="1.0" encoding="utf-16"?>
<IteModel iteVersion="ITEModel_1.1_" sourceTool="MDE" sourceModelPath=""  modelName="DispatcherOperationCompleteModel" label="DispatcherOperationCompleteModel" sourceBinaryPath="" ruleRuntimeNeedsUpdate="true" replacedInvalidIdentifiers="true" automated="false" referenceID="14051f89-a6fe-4732-a909-8a10254751e1" comment="" previewMode="false" stateBasedTestGeneration="1" xmlns="http://itebuild.ntdev.corp.microsoft.com/ite/ITEModel_1.1_.xsd">
    <StateVariables referenceID="9b499ae1-b904-4587-9b50-31dc07c1198f">
    </StateVariables>
    <ModelParameters referenceID="3a69dec6-30e2-4d1c-baac-85f117a9b5b0">
        <Parameters referenceID="b271f2d2-828b-4a12-9573-0cab56dfa1d4">
            <Parameter key_Name="CompleteTimeout" label="CompleteTimeout" key_ActionReferenceID="7daf85ac-9975-4478-8b0f-5e5ed0e51a39" comment="" dataType="" dataGenerationType="" dataGenerationValue="" includeInGeneration="true" includeInClusters="true" automated="false" isNumericInModel="false" inOutType="0" uiPersistentID="" hidden="false" persist="false" referenceID="c3951c08-059f-4ee2-a9f9-76ede9651023">
                <ParameterValue key_Name="None" label="None" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="69678b32-beab-4452-9edd-8da999676a3b" />
                <ParameterValue key_Name="0" label="0" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="495da66d-7253-4e42-9325-49d745ad2f8f" />
                <ParameterValue key_Name="100" label="100" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="07530a76-f4c9-4064-b933-eef32f809179" />
                <ParameterValue key_Name="800" label="800" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="ab4ed9c0-5815-48a3-902c-de88f0626a63" />
                <ParameterValue key_Name="1200" label="1200" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="f9228e0c-6367-48bb-86f3-16c147cb62b5" />
            </Parameter>
            <Parameter key_Name="DispatcherType" label="DispatcherType" key_ActionReferenceID="a426002b-0f2f-4819-9302-6e1a2382a585" comment="" dataType="" dataGenerationType="" dataGenerationValue="" includeInGeneration="true" includeInClusters="true" automated="false" isNumericInModel="false" inOutType="0" uiPersistentID="" hidden="false" persist="false" referenceID="18304d44-aa1e-4c10-90be-b177a487a7a8">
                <ParameterValue key_Name="Win32" label="Win32" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="bb81dca2-5689-4579-8c76-20a5c389b77f" />
                <ParameterValue key_Name="Avalon" label="Avalon" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="861bdf6c-39b4-474d-bed7-6647f3d6902f" />
            </Parameter>
            <Parameter key_Name="CompleteOriginThread" label="CompleteOriginThread" key_ActionReferenceID="7daf85ac-9975-4478-8b0f-5e5ed0e51a39" comment="" dataType="" dataGenerationType="" dataGenerationValue="" includeInGeneration="true" includeInClusters="true" automated="false" isNumericInModel="false" inOutType="0" uiPersistentID="" hidden="false" persist="false" referenceID="5afb2128-9ed2-48a0-b50b-05d8fb829646">
                <ParameterValue key_Name="DispatcherThread" label="DispatcherThread" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="91c1f497-0f2e-4b61-8160-5119f8bda419" />
                <ParameterValue key_Name="WorkerThreadMTA" label="WorkerThreadMTA" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="f4024105-f041-4337-94e7-83df8a8b4813" />
                <ParameterValue key_Name="WorkerThreadSTA" label="WorkerThreadSTA" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="17a6fbd8-dd34-456c-93e5-687633962fba" />
            </Parameter>
            <Parameter key_Name="EnqueuedPriority" label="EnqueuedPriority" key_ActionReferenceID="7daf85ac-9975-4478-8b0f-5e5ed0e51a39" comment="" dataType="" dataGenerationType="" dataGenerationValue="" includeInGeneration="true" includeInClusters="true" automated="false" isNumericInModel="false" inOutType="0" uiPersistentID="" hidden="false" persist="false" referenceID="10967c4b-df0c-44d3-9395-e008067e8eb0">
                <ParameterValue key_Name="Normal" label="Normal" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="f54bb56a-48fe-475d-a0af-a211ca7304f1" />
                <ParameterValue key_Name="Background" label="Background" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="801f75eb-9cad-4fd7-be3c-68794c73d009" />
            </Parameter>
            <Parameter key_Name="EnqueuedOriginThread" label="EnqueuedOriginThread" key_ActionReferenceID="7daf85ac-9975-4478-8b0f-5e5ed0e51a39" comment="" dataType="" dataGenerationType="" dataGenerationValue="" includeInGeneration="true" includeInClusters="true" automated="false" isNumericInModel="false" inOutType="0" uiPersistentID="" hidden="false" persist="false" referenceID="b54b942e-71d3-4969-bb33-9a2b2bb571b0">
                <ParameterValue key_Name="DispatcherThread" label="DispatcherThread" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="bada529b-7e5f-4889-a173-be686af87afb" />
                <ParameterValue key_Name="WorkerThreadMTA" label="WorkerThreadMTA" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="204e987f-dbd3-4bd2-8290-eb4c22b3d8fe" />
                <ParameterValue key_Name="WorkerThreadSTA" label="WorkerThreadSTA" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="09c4b89b-0384-4e5d-aca9-b17771774901" />
            </Parameter>
            <Parameter key_Name="KeepBusy" label="KeepBusy" key_ActionReferenceID="7daf85ac-9975-4478-8b0f-5e5ed0e51a39" comment="" dataType="" dataGenerationType="" dataGenerationValue="" includeInGeneration="true" includeInClusters="true" automated="false" isNumericInModel="true" inOutType="0" uiPersistentID="" hidden="false" persist="false" referenceID="2478e56e-38cb-4545-9d32-1769fe9b0944">
                <ParameterValue key_Name="0" label="0" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="08f67d72-cc2c-4c46-a316-9fa1cc5badc9" />
                <ParameterValue key_Name="500" label="500" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="b027bc1d-7b82-438a-a83f-ecf6d7211f38" />
                <ParameterValue key_Name="1000" label="1000" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="66f7b0df-9a61-4e45-bd13-25f9d3e891ed" />
                <ParameterValue key_Name="3000" label="3000" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="c5b345fe-99da-445f-98bf-6acb11bc4e7d" />
            </Parameter>
        </Parameters>
        <ParameterCombinationRules seed="1" referenceID="8f0ddde0-23d6-4332-9579-e9314e9dcd48">
            <ParameterCluster key_Name="CombinationGroup# 0" label="CombinationGroup# 0" comment="" combinatoryType="3" include="true" combinatoryOrder="3" referenceID="b5ccff28-258f-4299-9b45-2b8dc62e06c3">
                <ParameterClusterElement key_ParameterReferenceID="c3951c08-059f-4ee2-a9f9-76ede9651023" key_ModelReferenceID="" referenceID="f4738510-fde0-4fbc-9075-ae7bbcc83234" />
                <ParameterClusterElement key_ParameterReferenceID="5afb2128-9ed2-48a0-b50b-05d8fb829646" key_ModelReferenceID="" referenceID="87b3706b-cbd1-49b6-a780-2e25dbd5391a" />
                <ParameterClusterElement key_ParameterReferenceID="10967c4b-df0c-44d3-9395-e008067e8eb0" key_ModelReferenceID="" referenceID="b46017c1-4369-4b5a-89d9-aafe9a74c3e9" />
                <ParameterClusterElement key_ParameterReferenceID="b54b942e-71d3-4969-bb33-9a2b2bb571b0" key_ModelReferenceID="" referenceID="e5129769-d099-489b-8423-d047985b17f3" />
                <ParameterClusterElement key_ParameterReferenceID="2478e56e-38cb-4545-9d32-1769fe9b0944" key_ModelReferenceID="" referenceID="4a287248-15b6-45bb-bbb3-25f6b36a8f42" />
                <ParameterClusterElement key_ParameterReferenceID="18304d44-aa1e-4c10-90be-b177a487a7a8" key_ModelReferenceID="" referenceID="2fe1ced4-449e-4a71-a0a5-5f4a12db24ea" />
            </ParameterCluster>
        </ParameterCombinationRules>
    </ModelParameters>
    <Actions referenceID="916cdade-8976-4928-b87d-d913ca890d06">
        <Action key_Name="CompleteOperation" label="CompleteOperation" comment="" weight="1" disabled="false" defaultClusterReferenceID="" uiPersistentID="" uiPattern="" uiMethod="" automated="false" referenceID="7daf85ac-9975-4478-8b0f-5e5ed0e51a39">
            <ActionParameters referenceID="6aeb7724-345e-448b-8468-28420f1f81dd">
                <ActionParameter key_ActionParameterReferenceID="c3951c08-059f-4ee2-a9f9-76ede9651023" referenceID="e35eb083-1e35-42f0-a7bb-d5e523b55be6" />
                <ActionParameter key_ActionParameterReferenceID="5afb2128-9ed2-48a0-b50b-05d8fb829646" referenceID="6e25a10a-c20f-4512-ae5f-d5de83ec51f4" />
                <ActionParameter key_ActionParameterReferenceID="10967c4b-df0c-44d3-9395-e008067e8eb0" referenceID="01ddbc26-7de8-4122-96e6-fb80ca50c77e" />
                <ActionParameter key_ActionParameterReferenceID="b54b942e-71d3-4969-bb33-9a2b2bb571b0" referenceID="4113bc6e-2937-44ee-9d82-9b9a6a9e8bd4" />
                <ActionParameter key_ActionParameterReferenceID="2478e56e-38cb-4545-9d32-1769fe9b0944" referenceID="47fd899b-7a2a-4e82-a10f-146c55b6640b" />
            </ActionParameters>
        </Action>
        <Action key_Name="ChooseDispatcher" label="ChooseDispatcher" comment="" weight="1" disabled="false" defaultClusterReferenceID="" uiPersistentID="" uiPattern="" uiMethod="" automated="false" referenceID="a426002b-0f2f-4819-9302-6e1a2382a585">
            <ActionParameters referenceID="69815a57-8dad-4a6a-9da5-c9e077ab517b">
                <ActionParameter key_ActionParameterReferenceID="18304d44-aa1e-4c10-90be-b177a487a7a8" referenceID="93217aaf-4e9e-48df-a5e7-1b15caa019ff" />
            </ActionParameters>
        </Action>
        <Action key_Name="Validate" label="Validate" comment="" weight="1" disabled="false" defaultClusterReferenceID="" uiPersistentID="" uiPattern="" uiMethod="" automated="false" referenceID="c9fae961-1c83-4060-9bf3-4dbafa25117f" />
    </Actions>
    <TransitionRules ruleDLLData="" referenceID="0214e606-ee40-4c86-8e16-2c0fb4ac0adb" />
    <EntryPoints seed="1" referenceID="9727c782-fc0e-4e3b-b2e1-faca23430790" />
    <AssertionRules referenceID="4ad97df3-9abe-4cd6-ba0c-bc7608d984a9" />
    <ModelInfo overview="" constructionInfo="" referenceID="b2bc1a1a-eab2-473a-9a11-5c1ba6e2f262" />
    <ModelReferences referenceID="f494c18f-34de-43b5-b780-5f953ced28f4" />
    <ModelLinkRules referenceID="51e8a18e-3da8-4bd2-b925-8f1b1fb59f3f" />
    <TestQueries referenceID="14066ed5-6669-469b-bf0f-9196e153eccd">
        <TestQuery key_Name="Test Cases" label="Test Cases" testOutputFilePathName="&lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-16&quot;?&gt;&#xD;&#xA;&lt;StandAloneLocation xmlns:xsd=&quot;http://www.w3.org/2001/XMLSchema&quot; xmlns:xsi=&quot;http://www.w3.org/2001/XMLSchema-instance&quot;&gt;&#xD;&#xA;  &lt;ModelPathName&gt;E:\Documents and Settings\Microsoft\My Documents\DispatcherOperationModel.mbt&lt;/ModelPathName&gt;&#xD;&#xA;  &lt;TestCaseFileName&gt;E:\Documents and Settings\Microsoft\My Documents\OperationComplete_Stateless.xtc&lt;/TestCaseFileName&gt;&#xD;&#xA;&lt;/StandAloneLocation&gt;" comment="" isStateless="true" referenceID="a5e7ed06-138c-459a-b887-56c0d3f02d3e" maxTestCases="0" applyFilters="true" testOutputLocationType="Microsoft.Ite.StandAloneInterface.StandAloneLocation,Microsoft.Ite.StandAloneTcmInterface, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null~" externalDataXml="" externalDataType="" disabled="false">
            <TestPattern seed="1" referenceID="616bff1e-0661-4af3-84b0-060a95c94840">
                <TestPatternElement testPatternElementType="0" modelReferenceID="14051f89-a6fe-4732-a909-8a10254751e1" referenceID="09ccbbdf-d5ff-4e6d-8dd8-427b27b6c426">
                    <ActionTestPatternElement actionReferenceID="a426002b-0f2f-4819-9302-6e1a2382a585" referenceID="3bf53ebb-b2bd-494d-8e00-0a8dfba46469">
                        <ParameterTestPatternElement key_ParameterReferenceID="18304d44-aa1e-4c10-90be-b177a487a7a8" parameterValueReferenceID="" lowWeight="0" highWeight="0" validFilter="0" automatedFilter="0" bucketFilter="" referenceID="55f8324f-413f-4df0-88ec-808ff53c16e6" />
                    </ActionTestPatternElement>
                </TestPatternElement>
                <TestPatternElement testPatternElementType="0" modelReferenceID="14051f89-a6fe-4732-a909-8a10254751e1" referenceID="883c9153-c206-4b69-b7fa-4f82de7414f2">
                    <ActionTestPatternElement actionReferenceID="7daf85ac-9975-4478-8b0f-5e5ed0e51a39" referenceID="739c972d-66ef-4ff2-a58e-49e8242ff250">
                        <ParameterTestPatternElement key_ParameterReferenceID="c3951c08-059f-4ee2-a9f9-76ede9651023" parameterValueReferenceID="" lowWeight="0" highWeight="0" validFilter="0" automatedFilter="0" bucketFilter="" referenceID="597a52cc-1006-485b-8daf-c232a0708386" />
                    </ActionTestPatternElement>
                </TestPatternElement>
                <TestPatternElement testPatternElementType="0" modelReferenceID="14051f89-a6fe-4732-a909-8a10254751e1" referenceID="2e541800-8eb5-4304-ac46-cfc3471c1c9e">
                    <ActionTestPatternElement actionReferenceID="c9fae961-1c83-4060-9bf3-4dbafa25117f" referenceID="894a7896-36de-478c-b3c3-3b23a73964be" />
                </TestPatternElement>
            </TestPattern>
        </TestQuery>
    </TestQueries>
    <TestFilters referenceID="afdf8d70-3dd4-4ae9-8826-dd046453cf0d" />
    <CustomData referenceID="1ccee7ab-7f42-46ee-a3c8-9cff264fffc5" />
</IteModel>