<?xml version="1.0" encoding="utf-16"?>
<IteModel iteVersion="ITEModel_1.1_" sourceTool="MDE" sourceModelPath=""  modelName="CompatReaderModel" label="CompatReaderModel" sourceBinaryPath="" ruleRuntimeNeedsUpdate="true" replacedInvalidIdentifiers="true" automated="false" referenceID="7efd32e6-27e7-417c-9b22-788c9d82b791" comment="" previewMode="false" stateBasedTestGeneration="1" xmlns="http://itebuild.ntdev.corp.microsoft.com/ite/ITEModel_1.1_.xsd">
    <StateVariables referenceID="77be0f2e-cebd-4d07-951e-bdae00309740" />
    <ModelParameters referenceID="14866e9f-16f2-42ac-b92f-18577ec5797f">
        <Parameters referenceID="affba3d0-f66b-4ee3-9e63-237c8c56bca2">
            <Parameter key_Name="Scenario" label="Scenario" key_ActionReferenceID="4a2671a2-b909-4c6a-a308-2e68c7cb0732" comment="" dataType="" dataGenerationType="" dataGenerationValue="" includeInGeneration="true" includeInClusters="true" automated="false" isNumericInModel="false" inOutType="0" uiPersistentID="" hidden="false" persist="false" referenceID="96b4c7aa-ac19-4d84-aece-a01e5333f409">
                <ParameterValue key_Name="No_Choice" label="No_Choice" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="f6210118-a721-44c9-b4f0-d9bca017ff28" />
                <ParameterValue key_Name="Two_Fallbacks" label="Two_Fallbacks" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="f977e8e1-0af5-4f77-b719-ee20561aad95" />
                <ParameterValue key_Name="Fallback_Before_Choice" label="Fallback_Before_Choice" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="3982e1d5-db40-4f2b-8a67-97e0e735c43a" />
                <ParameterValue key_Name="Invalid_Child" label="Invalid_Child" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="cee90542-1649-447e-b931-5830f9d2ade6" />
                <ParameterValue key_Name="Choice_Without_Requires" label="Choice_Without_Requires" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="1659d240-ca35-430b-8eef-dc7e2c344676" />
                <ParameterValue key_Name="Empty_Requires_Value" label="Empty_Requires_Value" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="1ef3a72c-64f8-45ad-aa72-b3b6bcb00fa6" />
                <ParameterValue key_Name="Comma_Separated_Requires_Value" label="Comma_Separated_Requires_Value" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="7ac43119-47e3-41f9-8f9e-8969255e1015" />
                <ParameterValue key_Name="Undefined_Prefix_In_Requires" label="Undefined_Prefix_In_Requires" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="483e07b6-4323-4aad-8718-ee11251b41f7" />
                <ParameterValue key_Name="Requires_On_Fallback" label="Requires_On_Fallback" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="e3735d62-1c9b-4b3f-9309-02e8f5b759b6" />
            </Parameter>
        </Parameters>
        <ParameterCombinationRules seed="1" referenceID="c467724d-fb4f-406b-943e-7e7240b56126">
            <ParameterCluster key_Name="CombinationGroup# 0" label="CombinationGroup# 0" comment="" combinatoryType="0" include="true" combinatoryOrder="0" referenceID="36008288-1427-49e4-8a8a-a72affe6a8ca">
                <ParameterClusterElement key_ParameterReferenceID="96b4c7aa-ac19-4d84-aece-a01e5333f409" key_ModelReferenceID="" referenceID="4f01a3ad-66c3-4aeb-8fac-2f181ae36914" />
            </ParameterCluster>
        </ParameterCombinationRules>
    </ModelParameters>
    <Actions referenceID="a1be5a64-0e1e-493c-9f5d-4a8266e7d0a8">
        <Action key_Name="TestAlternateContent" label="TestAlternateContent" comment="" weight="1" disabled="false" defaultClusterReferenceID="" uiPersistentID="" uiPattern="" uiMethod="" automated="false" referenceID="4a2671a2-b909-4c6a-a308-2e68c7cb0732">
            <ActionParameters referenceID="4a2502d1-8f10-4eac-8cf2-19b05173a1e6">
                <ActionParameter key_ActionParameterReferenceID="96b4c7aa-ac19-4d84-aece-a01e5333f409" referenceID="e0660eb1-906d-421f-9fdd-95d27db40b66" />
            </ActionParameters>
        </Action>
    </Actions>
    <TransitionRules ruleDLLData="" referenceID="e1773520-2bd9-4d4b-9fc8-d560852ff634" />
    <EntryPoints seed="1" referenceID="a60dde2b-8b30-498c-b210-448ad82fa3bf" />
    <AssertionRules referenceID="2b911503-9e72-4dd0-9bb4-e8a4b24d922f" />
    <ModelInfo overview="" constructionInfo="" referenceID="ba6f1fe6-f546-4682-ba7d-58a0c25eed8d" />
    <ModelReferences referenceID="6bf89a9f-f5b6-4530-9eab-64f62b5ba3d0" />
    <ModelLinkRules referenceID="46e296e9-ac32-4614-a726-85e55f61414f" />
    <TestQueries referenceID="47838c35-8b57-4e16-9506-39eeba4b7562">
        <TestQuery key_Name="TestAlternateContent" label="TestAlternateContent" testOutputFilePathName="&lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-16&quot;?&gt;&#xD;&#xA;&lt;StandAloneLocation xmlns:xsd=&quot;http://www.w3.org/2001/XMLSchema&quot; xmlns:xsi=&quot;http://www.w3.org/2001/XMLSchema-instance&quot;&gt;&#xD;&#xA;  &lt;ModelPathName&gt;D:\Documents and Settings\snijsure\Desktop\CompatReader_AlternateContent.mbt&lt;/ModelPathName&gt;&#xD;&#xA;  &lt;TestCaseFileName&gt;F:\nt\testsrc\windowstestdata\redist\client\wcptests\core\bvt\parser\Errors\TestAlternateContent.xtc&lt;/TestCaseFileName&gt;&#xD;&#xA;&lt;/StandAloneLocation&gt;" comment="" isStateless="true" referenceID="f8170fd8-1906-4ba9-805f-0046714793bc" maxTestCases="0" applyFilters="true" testOutputLocationType="Microsoft.Ite.StandAloneInterface.StandAloneLocation,Microsoft.Ite.StandAloneTcmInterface, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null~" externalDataXml="" externalDataType="" disabled="false">
            <TestPattern seed="1" referenceID="4230d1f0-5ef0-46d2-8c04-131923aff016">
                <TestPatternElement testPatternElementType="0" modelReferenceID="7efd32e6-27e7-417c-9b22-788c9d82b791" referenceID="0f8f2d70-d9d0-48f7-9515-3a35212c6735">
                    <ActionTestPatternElement actionReferenceID="4a2671a2-b909-4c6a-a308-2e68c7cb0732" referenceID="30f0034f-cb06-45d5-ac35-97cc09a0934e">
                        <ParameterTestPatternElement key_ParameterReferenceID="96b4c7aa-ac19-4d84-aece-a01e5333f409" parameterValueReferenceID="" lowWeight="0" highWeight="0" validFilter="0" automatedFilter="0" bucketFilter="" referenceID="d993fca0-ca31-4e17-8de8-55eb5ebe49c0" />
                    </ActionTestPatternElement>
                </TestPatternElement>
            </TestPattern>
        </TestQuery>
    </TestQueries>
    <TestFilters referenceID="75a24237-e178-4db6-8f10-c197b09c1530" />
    <CustomData referenceID="f6dff570-c9d7-4304-bdff-e4d2fa253209" />
</IteModel>