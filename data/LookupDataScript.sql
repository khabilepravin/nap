delete from LookupValue
delete from LookupGroup

insert into LookupGroup(Id, [Name], Code) values(NEWID(), 'Numeracy', 'NumeracyCategories')
declare @groupId as uniqueidentifier
select @groupId = Id from LookupGroup where Code = 'NumeracyCategories'
print(@groupId)

insert into LookupValue(Id, [Name], Code, GroupId, [Description]) values(NEWID(), 'NumberSense', 'NumberSense', @groupId, 'Quantifying numbers, using additive and multiplicative strategies')
insert into LookupValue(Id, [Name], Code, GroupId, [Description]) values(NEWID(), 'Algebra', 'Algebra', @groupId, 'Using number patterns and thinking algebraically')
insert into LookupValue(Id, [Name], Code, GroupId, [Description]) values(NEWID(), 'ProportionalReasoning', 'ProportionalReasoning', @groupId, 'Operating and interpreting decimals, fractions, percentages, ratios and rates')
insert into LookupValue(Id, [Name], Code, GroupId, [Description]) values(NEWID(), 'Geometry', 'Geometry', @groupId, 'Understanding and using geometric properties and spatial reasoning')
insert into LookupValue(Id, [Name], Code, GroupId, [Description]) values(NEWID(), 'Statistical', 'Statistical', @groupId, 'Exploring chance and data')

insert into LookupGroup(Id, [Name], Code) values(NEWID(), 'Literacy', 'LiteracyCategories')
select @groupId = Id from LookupGroup where Code = 'LiteracyCategories'
print(@groupId)


insert into LookupValue(Id, [Name], Code, GroupId, [Description]) values(NEWID(), 'Grammer', 'Grammer', @groupId, 'Understanding the role of grammatical features in the construction of meaning in the texts they compose and comprehend')
insert into LookupValue(Id, [Name], Code, GroupId, [Description]) values(NEWID(), 'Text', 'Text', @groupId, 'Understanding how the spoken, written, visual and multimodal texts they compose and comprehend are structured to meet the range of purposes needed in the learning areas')
insert into LookupValue(Id, [Name], Code, GroupId, [Description]) values(NEWID(), 'WordKnowledge', 'WordKnowledge', @groupId, 'Understanding the increasingly specialised vocabulary and spelling needed to compose and comprehend learning area texts')
insert into LookupValue(Id, [Name], Code, GroupId, [Description]) values(NEWID(), 'VisualKnowledge', 'VisualKnowledge', @groupId, 'Understanding how visual information contributes to the meanings created in learning area texts')

