<?xml version="1.0" encoding="utf-16"?>
<IteModel iteVersion="ITEModel_1.1_" sourceTool="MDE" sourceModelPath=""  modelName="CompatReaderModel" label="CompatReaderModel" sourceBinaryPath="" ruleRuntimeNeedsUpdate="true" replacedInvalidIdentifiers="true" automated="false" referenceID="d6042876-b69b-478d-b0e3-5e0c0ec09d4c" comment="" previewMode="false" stateBasedTestGeneration="1" xmlns="http://itebuild.ntdev.corp.microsoft.com/ite/ITEModel_1.1_.xsd">
    <StateVariables referenceID="136518de-cb90-497c-8f12-37ad2f55e99a" />
    <ModelParameters referenceID="9e521a9a-d4dd-49b5-b303-499fb96c688b">
        <Parameters referenceID="15f3ae09-5b10-4707-b38c-f12d678ad2c5">
            <Parameter key_Name="MustUnderstandValue" label="MustUnderstandValue" key_ActionReferenceID="6affaa31-c0e5-4f02-871d-48150483e5cb" comment="" dataType="" dataGenerationType="" dataGenerationValue="" includeInGeneration="true" includeInClusters="true" automated="false" isNumericInModel="false" inOutType="0" uiPersistentID="" hidden="false" persist="false" referenceID="b987f538-5f27-486b-90b4-08039867a47c">
                <ParameterValue key_Name="Empty" label="Empty" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="f9a6b81b-6b9a-4062-9ad0-c1cd22f117bc" />
                <ParameterValue key_Name="v1" label="v1" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="19433501-7840-4705-8ee9-ed21cd04738d" />
                <ParameterValue key_Name="v1commav2" label="v1commav2" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="2673a0d3-e08f-449d-a126-d7f00f23bb98" />
                <ParameterValue key_Name="v5" label="v5" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="6b22f669-a289-43fa-b5d4-fd357e07bd5c" />
            </Parameter>
        </Parameters>
        <ParameterCombinationRules seed="1" referenceID="f9b4be18-4d27-4eaa-9a05-0e75f452f071">
            <ParameterCluster key_Name="CombinationGroup# 0" label="CombinationGroup# 0" comment="" combinatoryType="0" include="true" combinatoryOrder="0" referenceID="016c644e-46c4-47b2-a109-5c0d4e8956c7">
                <ParameterClusterElement key_ParameterReferenceID="b987f538-5f27-486b-90b4-08039867a47c" key_ModelReferenceID="" referenceID="2d1478b6-79eb-48cc-8cea-f10e198019eb" />
            </ParameterCluster>
        </ParameterCombinationRules>
    </ModelParameters>
    <Actions referenceID="e60418e5-a492-46e7-8fb3-1742601b7a9a">
        <Action key_Name="TestMustUnderstand" label="TestMustUnderstand" comment="" weight="1" disabled="false" defaultClusterReferenceID="" uiPersistentID="" uiPattern="" uiMethod="" automated="false" referenceID="6affaa31-c0e5-4f02-871d-48150483e5cb">
            <ActionParameters referenceID="0757f1b1-fa78-46ed-9711-d4a09c83b57b">
                <ActionParameter key_ActionParameterReferenceID="b987f538-5f27-486b-90b4-08039867a47c" referenceID="4f973237-929f-4a86-86c9-02062da78607" />
            </ActionParameters>
        </Action>
    </Actions>
    <TransitionRules ruleDLLData="" referenceID="f6019f4c-317b-4ee0-9ee0-805650b38ab7" />
    <EntryPoints seed="1" referenceID="55828ccc-ffb7-45d6-94d0-2dc028a506f8" />
    <AssertionRules referenceID="80bff2fa-39d7-484b-b557-56479d02b8d7" />
    <ModelInfo overview="" constructionInfo="" referenceID="749b0683-0742-48c4-812a-8c219cf093f4" />
    <ModelReferences referenceID="8571b075-f9c2-4f03-8967-f5f720ceb5ff" />
    <ModelLinkRules referenceID="31f9a5b3-6273-4ba6-97b7-6b40ee591537" />
    <TestQueries referenceID="622cd980-25ee-4c8b-b4a2-615092150259">
        <TestQuery key_Name="TestMustUnderstand" label="TestMustUnderstand" testOutputFilePathName="&lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-16&quot;?&gt;&#xD;&#xA;&lt;StandAloneLocation xmlns:xsd=&quot;http://www.w3.org/2001/XMLSchema&quot; xmlns:xsi=&quot;http://www.w3.org/2001/XMLSchema-instance&quot;&gt;&#xD;&#xA;  &lt;ModelPathName&gt;D:\Documents and Settings\snijsure\Desktop\CompatReader_MustUnderstand.mbt&lt;/ModelPathName&gt;&#xD;&#xA;  &lt;TestCaseFileName&gt;F:\nt\testsrc\windowstestdata\redist\client\wcptests\core\bvt\parser\Errors\TestMustUnderstand.xtc&lt;/TestCaseFileName&gt;&#xD;&#xA;&lt;/StandAloneLocation&gt;" comment="" isStateless="true" referenceID="49744ed8-c3e2-43c8-8cb1-abc1ccb6f21c" maxTestCases="0" applyFilters="true" testOutputLocationType="Microsoft.Ite.StandAloneInterface.StandAloneLocation,Microsoft.Ite.StandAloneTcmInterface, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null~" externalDataXml="" externalDataType="" disabled="false">
            <TestPattern seed="1" referenceID="28b8d14f-3d8d-4052-94b1-7d26fb979900">
                <TestPatternElement testPatternElementType="0" modelReferenceID="d6042876-b69b-478d-b0e3-5e0c0ec09d4c" referenceID="d4c2ab46-5a89-4799-a39c-9d5fe898556d">
                    <ActionTestPatternElement actionReferenceID="6affaa31-c0e5-4f02-871d-48150483e5cb" referenceID="8edfd0cf-bf91-4bb4-8f73-bcee7ef0a3cf">
                        <ParameterTestPatternElement key_ParameterReferenceID="b987f538-5f27-486b-90b4-08039867a47c" parameterValueReferenceID="" lowWeight="0" highWeight="0" validFilter="0" automatedFilter="0" bucketFilter="" referenceID="fd9754f8-4775-4103-bc7c-784f92683715" />
                    </ActionTestPatternElement>
                </TestPatternElement>
            </TestPattern>
        </TestQuery>
    </TestQueries>
    <TestFilters referenceID="4fd05864-4837-4ac1-86fc-787bfbcb7a22" />
    <CustomData referenceID="5ae231ca-b3b9-43b2-a22b-737ebc8b024b" />
</IteModel>