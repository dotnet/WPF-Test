<?xml version="1.0" encoding="utf-16"?>
<IteModel iteVersion="ITEModel_1.1_" sourceTool="MDE" sourceModelPath=""  modelName="DestroyHwndHostModel" label="DestroyHwndHostModel" sourceBinaryPath="" ruleRuntimeNeedsUpdate="true" replacedInvalidIdentifiers="true" automated="false" referenceID="153225ae-08c9-4c6e-bd4c-99cb17ff0266" comment="" previewMode="false" stateBasedTestGeneration="1" xmlns="http://itebuild.ntdev.corp.microsoft.com/ite/ITEModel_1.1_.xsd">
    <StateVariables referenceID="9cb443ca-df39-4e7e-94da-e7808df151cc" />
    <ModelParameters referenceID="dcfe6435-27d0-4a55-91ce-b420589d63ca">
        <Parameters referenceID="5dd08fcb-83a1-41b1-b694-d10fd6d52490">
            <Parameter key_Name="HostControlType" label="HostControlType" key_ActionReferenceID="b918c25c-3b7c-4b76-9b79-29a86894918f" comment="" dataType="" dataGenerationType="" dataGenerationValue="" includeInGeneration="true" includeInClusters="true" automated="false" isNumericInModel="false" inOutType="0" uiPersistentID="" hidden="false" persist="false" referenceID="716c0db9-c0ff-4876-ac4c-359285877011">
                <ParameterValue key_Name="Win32ButtonCtrl" label="Win32ButtonCtrl" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="3483a32b-2092-4128-a34a-0e49cfbc34da" />
            </Parameter>
            <Parameter key_Name="TypeOfDestroyCall" label="TypeOfDestroyCall" key_ActionReferenceID="b918c25c-3b7c-4b76-9b79-29a86894918f" comment="" dataType="" dataGenerationType="" dataGenerationValue="" includeInGeneration="true" includeInClusters="true" automated="false" isNumericInModel="false" inOutType="0" uiPersistentID="" hidden="false" persist="false" referenceID="13bd4697-4bbd-4adc-942d-17ad2b71a3ce">
                <ParameterValue key_Name="WM_DESTROY" label="WM_DESTROY" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="fd14d353-5b94-4144-9948-0dcfb573aee7" />
                <ParameterValue key_Name="Dispose" label="Dispose" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="0fbbb108-7927-4483-8081-4f459557e20e" />
                <ParameterValue key_Name="DispatcherShutdown" label="DispatcherShutdown" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="590262e7-3b20-4171-869b-9883cdfaefb6" />
            </Parameter>
            <Parameter key_Name="HwndHostTreeState" label="HwndHostTreeState" key_ActionReferenceID="b918c25c-3b7c-4b76-9b79-29a86894918f" comment="" dataType="" dataGenerationType="" dataGenerationValue="" includeInGeneration="true" includeInClusters="true" automated="false" isNumericInModel="false" inOutType="0" uiPersistentID="" hidden="false" persist="false" referenceID="a563673c-e417-4215-b203-37d9620a5def">
                <ParameterValue key_Name="NoAddedToSource" label="NoAddedToSource" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="327b559f-e0ae-439c-8f68-122b5f9ea025" />
                <ParameterValue key_Name="AddedToSource" label="AddedToSource" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="de461d51-d394-4bbe-b3d7-2aa7c5e19dcb" />
                <ParameterValue key_Name="RemovedFromSource" label="RemovedFromSource" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="d3b7a174-4e2a-43de-8f6a-c41e0964512a" />
            </Parameter>
            <Parameter key_Name="SourceType" label="SourceType" key_ActionReferenceID="b918c25c-3b7c-4b76-9b79-29a86894918f" comment="" dataType="" dataGenerationType="" dataGenerationValue="" includeInGeneration="true" includeInClusters="true" automated="false" isNumericInModel="false" inOutType="0" uiPersistentID="" hidden="false" persist="false" referenceID="18237da2-1bc3-480f-a81f-0022f6511f28">
                <ParameterValue key_Name="NoCompile_Window" label="NoCompile_Window" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="a9b83ab5-7d7e-4e18-bfed-5ab3d038a9f1" />
                <ParameterValue key_Name="NoCompile_HwndSource" label="NoCompile_HwndSource" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="bd48e1f7-2ff0-4f45-8cb3-2739c69ec52b" />
                <ParameterValue key_Name="Compile_Browser" label="Compile_Browser" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="ccc9526d-bb3f-4576-9f86-14902a709377" />
                <ParameterValue key_Name="Compile_Window" label="Compile_Window" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="912ce80d-25cf-4719-9e19-7a13574096a9" />
                <ParameterValue key_Name="Compile_HwndSource" label="Compile_HwndSource" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="9f119aa5-aa07-449d-9e8d-e826471a8504" />
            </Parameter>
        </Parameters>
        <ParameterCombinationRules seed="1" referenceID="8af1833c-9465-471c-98d5-cad24208ce98">
            <ParameterCluster key_Name="CombinationGroup# 0" label="CombinationGroup# 0" comment="" combinatoryType="0" include="true" combinatoryOrder="0" referenceID="57d1a0a1-2984-43c9-97fb-c906b54f9ddf">
                <ParameterClusterElement key_ParameterReferenceID="716c0db9-c0ff-4876-ac4c-359285877011" key_ModelReferenceID="" referenceID="c410bd7e-4b89-461d-99ed-05390d90ff46" />
                <ParameterClusterElement key_ParameterReferenceID="13bd4697-4bbd-4adc-942d-17ad2b71a3ce" key_ModelReferenceID="" referenceID="19c909a3-bd05-4103-82ce-550ff0a535d0" />
                <ParameterClusterElement key_ParameterReferenceID="a563673c-e417-4215-b203-37d9620a5def" key_ModelReferenceID="" referenceID="b1e4e076-0cb8-47e9-a60a-e8dec470742c" />
                <ParameterClusterElement key_ParameterReferenceID="18237da2-1bc3-480f-a81f-0022f6511f28" key_ModelReferenceID="" referenceID="e89e2647-d454-4c5c-8fb7-ff9b48717a98" />
            </ParameterCluster>
        </ParameterCombinationRules>
    </ModelParameters>
    <Actions referenceID="5bb20b66-a455-4859-bdee-79924a465b0d">
        <Action key_Name="SetupAndRunTest" label="SetupAndRunTest" comment="" weight="1" disabled="false" defaultClusterReferenceID="" uiPersistentID="" uiPattern="" uiMethod="" automated="false" referenceID="b918c25c-3b7c-4b76-9b79-29a86894918f">
            <ActionParameters referenceID="4cfc7d46-3890-47f9-833e-9256e1d0ca90">
                <ActionParameter key_ActionParameterReferenceID="716c0db9-c0ff-4876-ac4c-359285877011" referenceID="44da6cc8-d27d-45e2-83b9-ba8344efa5d9" />
                <ActionParameter key_ActionParameterReferenceID="13bd4697-4bbd-4adc-942d-17ad2b71a3ce" referenceID="3a392343-3696-48d3-b8c8-11ed60ef3675" />
                <ActionParameter key_ActionParameterReferenceID="a563673c-e417-4215-b203-37d9620a5def" referenceID="55b7fdd8-3187-48c3-b0c2-756db7865d75" />
                <ActionParameter key_ActionParameterReferenceID="18237da2-1bc3-480f-a81f-0022f6511f28" referenceID="7268d807-d244-4677-922b-f9a6d827072b" />
            </ActionParameters>
        </Action>
    </Actions>
    <TransitionRules ruleDLLData="" referenceID="bfc03157-4eef-4b1d-865f-5c7c5f84285e" />
    <EntryPoints seed="1" referenceID="3ed72412-18ab-4c4e-af1c-a9930ee3ce22" />
    <AssertionRules referenceID="17e5ef39-63f2-4454-999b-7fdbf62e0e0c" />
    <ModelInfo overview="" constructionInfo="" referenceID="4e16026f-9f2b-4454-9866-3d07a642563e" />
    <ModelReferences referenceID="7aec8150-6268-4cc9-9fec-71ac557449d4" />
    <ModelLinkRules referenceID="f1253443-1eaa-4a4d-9704-58b82955dfb9" />
    <TestQueries referenceID="4d1786d8-ef33-4caf-bbca-d0329835c2e4">
        <TestQuery key_Name="DestroyHwndHostModelSingleDispatcher" label="DestroyHwndHostModelSingleDispatcher" testOutputFilePathName="&lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-16&quot;?&gt;&#xD;&#xA;&lt;StandAloneLocation xmlns:xsd=&quot;http://www.w3.org/2001/XMLSchema&quot; xmlns:xsi=&quot;http://www.w3.org/2001/XMLSchema-instance&quot;&gt;&#xD;&#xA;  &lt;ModelPathName&gt;E:\Documents and Settings\Microsoft\My Documents\DestroyHwndHostModel.mbt&lt;/ModelPathName&gt;&#xD;&#xA;  &lt;TestCaseFileName&gt;E:\Documents and Settings\Microsoft\My Documents\DestroyHwndHostModelSingleDispatcher.xtc&lt;/TestCaseFileName&gt;&#xD;&#xA;&lt;/StandAloneLocation&gt;" comment="" isStateless="true" referenceID="50ec7e27-05c7-4dc0-87ef-716ff65d2ff0" maxTestCases="0" applyFilters="true" testOutputLocationType="Microsoft.Ite.StandAloneInterface.StandAloneLocation,Microsoft.Ite.StandAloneTcmInterface, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null~" externalDataXml="" externalDataType="" disabled="false">
            <TestPattern seed="1" referenceID="58dfd221-564c-4622-9d70-f54281046ee5">
                <TestPatternElement testPatternElementType="0" modelReferenceID="153225ae-08c9-4c6e-bd4c-99cb17ff0266" referenceID="4362effa-daea-4974-95c8-3a03356d5581">
                    <ActionTestPatternElement actionReferenceID="b918c25c-3b7c-4b76-9b79-29a86894918f" referenceID="6b9230fa-c245-4358-a464-4d2f9d00736c">
                        <ParameterTestPatternElement key_ParameterReferenceID="716c0db9-c0ff-4876-ac4c-359285877011" parameterValueReferenceID="" lowWeight="0" highWeight="0" validFilter="0" automatedFilter="0" bucketFilter="" referenceID="e4710d9e-bf36-403f-84a3-56d76b28336e" />
                        <ParameterTestPatternElement key_ParameterReferenceID="13bd4697-4bbd-4adc-942d-17ad2b71a3ce" parameterValueReferenceID="" lowWeight="0" highWeight="0" validFilter="0" automatedFilter="0" bucketFilter="" referenceID="d83bfbdd-0edf-4247-a739-0e20f65d08dc" />
                        <ParameterTestPatternElement key_ParameterReferenceID="a563673c-e417-4215-b203-37d9620a5def" parameterValueReferenceID="" lowWeight="0" highWeight="0" validFilter="0" automatedFilter="0" bucketFilter="" referenceID="f21d6f74-b966-43ef-9b5b-ffe03b9d9444" />
                        <ParameterTestPatternElement key_ParameterReferenceID="18237da2-1bc3-480f-a81f-0022f6511f28" parameterValueReferenceID="" lowWeight="0" highWeight="0" validFilter="0" automatedFilter="0" bucketFilter="" referenceID="a61ec078-585f-4ac5-a8f2-be049bba88de" />
                    </ActionTestPatternElement>
                </TestPatternElement>
            </TestPattern>
        </TestQuery>
    </TestQueries>
    <TestFilters referenceID="3e73e7eb-fe3a-4923-b47d-d75f6658c98f" />
    <CustomData referenceID="7e645601-8a8f-4127-bff6-2c8377d9b5e9" />
</IteModel>