<?xml version="1.0" encoding="utf-16"?>
<IteModel iteVersion="ITEModel_1.1_" sourceTool="MDE" sourceModelPath=""  modelName="CompatReaderModel" label="CompatReaderModel" sourceBinaryPath="" ruleRuntimeNeedsUpdate="true" replacedInvalidIdentifiers="true" automated="false" referenceID="b139409b-563e-459d-a334-2dd6cfe8496b" comment="" previewMode="false" stateBasedTestGeneration="1" xmlns="http://itebuild.ntdev.corp.microsoft.com/ite/ITEModel_1.1_.xsd">
    <StateVariables referenceID="1bad96f3-6d65-4888-9e51-2e5832f4b636" />
    <ModelParameters referenceID="2a5d61a0-1105-419c-9a05-691ed275d10d">
        <Parameters referenceID="c5cf48e8-9ea0-4c90-ab37-c3dae63a21c8">
            <Parameter key_Name="IgnorableValue" label="IgnorableValue" key_ActionReferenceID="bceefe78-77f8-433c-9ed4-16da88dd9b0f" comment="" dataType="" dataGenerationType="" dataGenerationValue="" includeInGeneration="true" includeInClusters="true" automated="false" isNumericInModel="false" inOutType="0" uiPersistentID="" hidden="false" persist="false" referenceID="73e48ce3-705b-4786-ba70-10bbf3fd8b8a">
                <ParameterValue key_Name="Empty" label="Empty" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="b2ccc88b-e4f8-48af-9945-faccb3c592a2" />
                <ParameterValue key_Name="v1" label="v1" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="ad05dacb-4cda-42dc-8f0c-7aaa56fec234" />
                <ParameterValue key_Name="v1commav2" label="v1commav2" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="e3c1cae1-068b-42d2-a8ba-5aba77a49a0d" />
                <ParameterValue key_Name="v5" label="v5" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="7d77a0b8-fa14-4986-bc75-2d97234b7a4a" />
            </Parameter>
        </Parameters>
        <ParameterCombinationRules seed="1" referenceID="7ec8fd0f-0f8a-4f8f-a5d1-8083cbf5512b">
            <ParameterCluster key_Name="CombinationGroup# 0" label="CombinationGroup# 0" comment="" combinatoryType="0" include="true" combinatoryOrder="0" referenceID="f9d6ce8a-8f7e-4376-8a0a-89923705a7e7">
                <ParameterClusterElement key_ParameterReferenceID="73e48ce3-705b-4786-ba70-10bbf3fd8b8a" key_ModelReferenceID="" referenceID="dae74900-a09a-4610-85b5-e43e6594e7cb" />
            </ParameterCluster>
        </ParameterCombinationRules>
    </ModelParameters>
    <Actions referenceID="5857055f-1f94-44f5-bb9a-af9053934e54">
        <Action key_Name="TestIgnorable" label="TestIgnorable" comment="" weight="1" disabled="false" defaultClusterReferenceID="" uiPersistentID="" uiPattern="" uiMethod="" automated="false" referenceID="bceefe78-77f8-433c-9ed4-16da88dd9b0f">
            <ActionParameters referenceID="ada1b1e3-1e16-4b26-8758-6283566dc1fa">
                <ActionParameter key_ActionParameterReferenceID="73e48ce3-705b-4786-ba70-10bbf3fd8b8a" referenceID="2872f5f9-c410-41f8-94cd-cff0af0e6cb0" />
            </ActionParameters>
        </Action>
    </Actions>
    <TransitionRules ruleDLLData="" referenceID="f1735bff-c0fb-4bb1-afe5-8876d1665c32" />
    <EntryPoints seed="1" referenceID="52d52342-c9fb-4379-aaa8-112a3151774a" />
    <AssertionRules referenceID="d21ec8b5-9a80-4509-b082-756534d8c6d4" />
    <ModelInfo overview="" constructionInfo="" referenceID="7e333ff2-60ab-4fba-b047-102270b118f5" />
    <ModelReferences referenceID="845978f8-a51d-4f2c-8f0f-5da8ada4b0d9" />
    <ModelLinkRules referenceID="be5b0616-0658-4dff-aca7-dd70f8db89fa" />
    <TestQueries referenceID="3b47556a-df82-49f9-bc2d-f534b1018249">
        <TestQuery key_Name="Ignorable" label="Ignorable" testOutputFilePathName="&lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-16&quot;?&gt;&#xD;&#xA;&lt;StandAloneLocation xmlns:xsd=&quot;http://www.w3.org/2001/XMLSchema&quot; xmlns:xsi=&quot;http://www.w3.org/2001/XMLSchema-instance&quot;&gt;&#xD;&#xA;  &lt;ModelPathName&gt;D:\Documents and Settings\snijsure\Desktop\CompatReader.mbt&lt;/ModelPathName&gt;&#xD;&#xA;  &lt;TestCaseFileName&gt;F:\nt\testsrc\windowstestdata\redist\client\wcptests\core\bvt\parser\Errors\TestIgnorable.xtc&lt;/TestCaseFileName&gt;&#xD;&#xA;&lt;/StandAloneLocation&gt;" comment="" isStateless="true" referenceID="1c8bc3d5-8c3a-4fbd-ac6b-60edd8328fb0" maxTestCases="0" applyFilters="true" testOutputLocationType="Microsoft.Ite.StandAloneInterface.StandAloneLocation,Microsoft.Ite.StandAloneTcmInterface, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null~" externalDataXml="" externalDataType="" disabled="false">
            <TestPattern seed="1" referenceID="fd36ab9a-1e6e-4ce9-9045-2deca517151d">
                <TestPatternElement testPatternElementType="0" modelReferenceID="b139409b-563e-459d-a334-2dd6cfe8496b" referenceID="d7930a72-efb4-47d9-94b0-3263d353ed0a">
                    <ActionTestPatternElement actionReferenceID="bceefe78-77f8-433c-9ed4-16da88dd9b0f" referenceID="213b11ea-cde6-4517-b61a-36057cc0c48c" />
                </TestPatternElement>
            </TestPattern>
        </TestQuery>
    </TestQueries>
    <TestFilters referenceID="4b319435-f53c-4d7f-a40a-5c22cca873dc" />
    <CustomData referenceID="fd8eda52-a850-4920-a4ec-52215077db84" />
</IteModel>